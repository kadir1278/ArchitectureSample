using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Dto.Company;
using EntityLayer.Dto.User;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfCompanyDal : EfEntityRepository<Company, SystemContext>, ICompanyDal
    {
        public EfCompanyDal(SystemContext context) : base(context)
        {

        }
    }
}
