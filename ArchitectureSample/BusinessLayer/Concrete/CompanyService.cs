using BusinessLayer.Abstract;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.Company;
using EntityLayer.Entity;

namespace BusinessLayer.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly IWorker _worker;
        private readonly IProjectOwnerService _projectOwnerService;
        private readonly CancellationToken _ct;

        public CompanyService(IWorker worker, IProjectOwnerService projectOwnerService)
        {
            _worker = worker;
            _projectOwnerService = projectOwnerService;
        }
        public IDataResult<bool> ActiveStatusToCompany(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Company> AddCompany(CompanyAddDto companyAddDto)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                var projectOwner = _projectOwnerService.GetProjectOwnerByRequestDomain();
                if (!projectOwner.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<Company>("Domain kaydı bulunamadı");
                }
                companyAddDto.ProjectOwnerId = projectOwner.Data.Id;
                var addedCompany = _worker.CompanyDal.Add(companyAddDto, _ct);
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

        public IDataResult<bool> DeactiveStatusToCompany(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Company> DeleteCompany(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Company> GetCompany(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<ICollection<Company>> GetCompanyCollection()
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getCompany = _worker.CompanyDal.Queryable().ToList();

                if (getCompany == null)
                    return new ErrorDataResult<ICollection<Company>>(String.Join("-", "Kullanıcı bulunamadı"));

                return new SuccessDataResult<ICollection<Company>>(getCompany);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ICollection<Company>>(ex);
            }
        }
    }
}
