using CoreLayer.DataAccess.Abstract;
using EntityLayer.Dto.Company;
using EntityLayer.Dto.User;
using EntityLayer.Entity;

namespace DataAccessLayer.Absctract
{
    public interface ICompanyDal : IEntityRepository<Company, CompanyAddDto, CompanyUpdateDto, CompanyGetDto>
    {
    }
}
