using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Dto.ProjectOwner;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface IProjectOwnerService
    {
        public IDataResult<ProjectOwner> AddProjectOwner(ProjectOwnerAddDto projectOwnerAddDto);
        public IDataResult<bool> DeleteProjectOwner(Guid projectOwnerId);
        public IDataResult<ProjectOwner> GetProjectOwner(Guid projectOwnerId);
        public IDataResult<bool> ActiveStatusToProjectOwnerId(Guid projectOwnerId);
        public IDataResult<bool> DeactiveStatusToProjectOwnerId(Guid projectOwnerId);
        public IDataResult<ICollection<ProjectOwner>> GetProjectOwnerCollection();
    }
}
