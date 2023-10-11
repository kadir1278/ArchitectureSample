using CoreLayer.DataAccess.Concrete;
using DataAccessLayer.Absctract;
using DataAccessLayer.Context;
using EntityLayer.Dto.ProjectOwner;
using EntityLayer.Entity;

namespace DataAccessLayer.Concrete
{
    public class EfProjectOwnerDal : EfEntityRepository<ProjectOwner, ProjectOwnerAddDto, ProjectOwnerUpdateDto, ProjectOwnerGetDto, SystemContext>, IProjectOwnerDal
    {
        public EfProjectOwnerDal(SystemContext context) : base(context)
        {

        }
    }
}
