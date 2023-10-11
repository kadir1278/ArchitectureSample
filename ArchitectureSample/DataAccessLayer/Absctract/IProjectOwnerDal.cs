using CoreLayer.DataAccess.Abstract;
using EntityLayer.Dto.ProjectOwner;
using EntityLayer.Entity;

namespace DataAccessLayer.Absctract
{
    public interface IProjectOwnerDal : IEntityRepository<ProjectOwner, ProjectOwnerAddDto, ProjectOwnerUpdateDto, ProjectOwnerGetDto>
    {
    }
}
