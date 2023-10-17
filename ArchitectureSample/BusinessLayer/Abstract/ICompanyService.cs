using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.Company;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface ICompanyService
    {
        public IDataResult<Company> AddCompany(CompanyAddDto companyAddDto);
        public IDataResult<Company> DeleteCompany(Guid companyId);
        public IDataResult<Company> GetCompany(Guid companyId);
        public IDataResult<bool> ActiveStatusToCompany(Guid companyId);
        public IDataResult<bool> DeactiveStatusToCompany(Guid companyId);
        public IDataResult<ICollection<Company>> GetCompanyCollection();
    }
}
