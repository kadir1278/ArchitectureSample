using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.Company;
using EntityLayer.Dto.User;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface ICompanyService
    {
        public IDataResult<Company> AddCompany(CompanyAddDto userAddDto);
        public IDataResult<ICollection<Company>> GetCompanyCollection();
        public IDataResult<CompanyGetDto> GetCompanyById(Guid id);
    }
}
