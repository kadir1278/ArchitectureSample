using AttributeExtensionLayer.MethodAttribute.Interceptors.AutoFac.MethodInteceptors;
using BusinessLayer.Abstract;
using CoreLayer.DataAccess.Enums;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.Company;
using EntityLayer.Entity;
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


        public IDataResult<Company> AddCompany(CompanyAddDto companyAddDto)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                var addedCompany = _companyDal.Add(companyAddDto, _ct);
                if (!addedCompany.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<Company>("Kullanıcı eklenemedi");
                }
                _worker.CommitAndSaveChanges();
                return addedCompany;
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<Company>(ex);
            }
        }

        [IpCheckOperationAspect]
        [SecuredOperation(PermissionEnum.Ekle)]
        public IDataResult<ICollection<Company>> GetCompanyCollection()
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getCompany = _companyDal.Queryable().ToList();

                if (getCompany is null) return new ErrorDataResult<ICollection<Company>>(String.Join("-", "Kullanıcı bulunamadı"));
                return new SuccessDataResult<ICollection<Company>>(getCompany);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IDataResult<CompanyGetDto> GetCompanyById(Guid id)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getCompany = _companyDal.GetById(id);
                if (!getCompany.IsSuccess || getCompany.Data is null)
                    return new ErrorDataResult<CompanyGetDto>(getCompany.Messages);

                return getCompany;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
