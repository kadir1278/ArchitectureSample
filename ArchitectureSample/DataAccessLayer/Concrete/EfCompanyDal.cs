using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
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
