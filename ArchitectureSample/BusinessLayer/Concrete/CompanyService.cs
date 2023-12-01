using AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors;
using BusinessLayer.Abstract;
using CoreLayer.DataAccess.Enums;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.Company;
using EntityLayer.Dto.Company.Request;
using EntityLayer.Dto.Company.Response;
using EntityLayer.Entity;
using Mapster;
using System.Security;

namespace BusinessLayer.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly IWorker _worker;
        private readonly ICompanyDal _companyDal;
        private readonly CancellationToken _ct;

        public CompanyService(IWorker worker, ICompanyDal companyDal)
        {
            _worker = worker;
            _companyDal = companyDal;
        }


        public IDataResult<CompanyAddResponseDto> AddCompany(CompanyAddRequestDto companyAddDto)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();
                Company company = companyAddDto.Adapt<Company>();
                var addedCompany = _companyDal.Add(company, _ct);
                if (!addedCompany.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<CompanyAddResponseDto>("Kullanıcı eklenemedi");
                }
                _worker.CommitAndSaveChanges();
                return new SuccessDataResult<CompanyAddResponseDto>(addedCompany.Adapt<CompanyAddResponseDto>());
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<CompanyAddResponseDto>(ex);
            }
        }

        [IpCheckOperationAspect]
        //  [SecuredOperation(PermissionEnum.Ekle)]
        public IDataResult<ICollection<CompanyListResponseDto>> GetCompanyCollection()
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getCompany = _companyDal.Queryable().ToList();

                if (getCompany is null) return new ErrorDataResult<ICollection<CompanyListResponseDto>>(String.Join("-", "Kullanıcı bulunamadı"));
                return new SuccessDataResult<ICollection<CompanyListResponseDto>>(getCompany.Adapt<ICollection<CompanyListResponseDto>>());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IDataResult<CompanyGetByIdResponseDto> GetCompanyById(Guid id)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getCompany = _companyDal.GetById(id);
                if (!getCompany.IsSuccess || getCompany.Data is null)
                    return new ErrorDataResult<CompanyGetByIdResponseDto>(getCompany.Messages);

                return new SuccessDataResult<CompanyGetByIdResponseDto>(getCompany.Data.Adapt<CompanyGetByIdResponseDto>());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
