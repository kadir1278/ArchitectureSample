using BusinessLayer.Abstract;
using CoreLayer.Helper;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Absctract;
using EntityLayer.Dto.ProjectOwner;
using EntityLayer.Entity;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
    public class ProjectOwnerService : IProjectOwnerService
    {
        private readonly IWorker _worker;
        private readonly CancellationToken _ct;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProjectOwnerService(IWorker worker, IHttpContextAccessor httpContextAccessor)
        {
            _worker = worker;
            _httpContextAccessor = httpContextAccessor;
        }

        public IDataResult<bool> ActiveStatusToProjectOwnerId(Guid projectOwnerId)
        {
            try
            {
                ProjectOwner? getProjectOwnerByGuid = _worker.ProjectOwnerDal.Queryable()
                                                                   .Where(x => x.Id == projectOwnerId)
                                                                   .First();

                if (getProjectOwnerByGuid == null) return new ErrorDataResult<bool>("Proje bulunamadı");

                var projectOwnerUpdateDto = getProjectOwnerByGuid.Adapt<ProjectOwnerUpdateDto>();
                projectOwnerUpdateDto.IsActive = true;
                var updatedProjectOwner = _worker.ProjectOwnerDal.Update(projectOwnerUpdateDto, _ct);

                if (!updatedProjectOwner.IsSuccess)
                    return new ErrorDataResult<bool>(String.Join("-", updatedProjectOwner.Messages));

                return new SuccessDataResult<bool>(true);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<bool>(ex);
            }
        }

        public IDataResult<ProjectOwner> AddProjectOwner(ProjectOwnerAddDto projectOwnerAddDto)
        {
            try
            {
                bool checkDomain = _worker.ProjectOwnerDal.Queryable().Where(x => x.Domain == projectOwnerAddDto.Domain).Count() != 1;
                if (!checkDomain) return new ErrorDataResult<ProjectOwner>("Domain registered");

                IDataResult<ProjectOwner> addedProjectOwner = _worker.ProjectOwnerDal.Add(projectOwnerAddDto, _ct);

                if (!addedProjectOwner.IsSuccess)
                    return new ErrorDataResult<ProjectOwner>(String.Join("-", addedProjectOwner.Messages));

                return addedProjectOwner;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProjectOwner>(ex);
            }
        }

        public IDataResult<bool> DeactiveStatusToProjectOwnerId(Guid projectOwnerId)
        {
            try
            {
                ProjectOwner? getProjectOwnerByGuid = _worker.ProjectOwnerDal.Queryable()
                                                                   .Where(x => x.Id == projectOwnerId)
                                                                   .First();

                if (getProjectOwnerByGuid == null) return new ErrorDataResult<bool>("Proje bulunamadı");

                var projectOwnerUpdateDto = getProjectOwnerByGuid.Adapt<ProjectOwnerUpdateDto>();
                projectOwnerUpdateDto.IsActive = false;
                var updatedProjectOwner = _worker.ProjectOwnerDal.Update(projectOwnerUpdateDto, _ct);

                if (!updatedProjectOwner.IsSuccess)
                    return new ErrorDataResult<bool>(String.Join("-", updatedProjectOwner.Messages));

                return new SuccessDataResult<bool>(true);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<bool>(ex);
            }
        }

        public IDataResult<bool> DeleteProjectOwner(Guid projectOwnerId)
        {
            try
            {
                var deletedProjectOwner = _worker.ProjectOwnerDal.SoftDelete(projectOwnerId, _ct);

                if (!deletedProjectOwner.IsSuccess)
                    return new ErrorDataResult<bool>(String.Join("-", deletedProjectOwner.Messages));

                return new SuccessDataResult<bool>(true);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<bool>(ex);
            }
        }

        public IDataResult<ProjectOwner> GetProjectOwner(Guid projectOwnerId)
        {
            try
            {
                var getProjectOwner = _worker.ProjectOwnerDal.Queryable()
                                                             .Where(x => x.Id == projectOwnerId)
                                                             .First();

                if (getProjectOwner == null)
                    return new ErrorDataResult<ProjectOwner>(String.Join("-", "Proje bulunamadı"));

                return new SuccessDataResult<ProjectOwner>(getProjectOwner);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ProjectOwner>(ex);
            }
        }

        public IDataResult<ICollection<ProjectOwner>> GetProjectOwnerCollection()
        {
            try
            {
                var getProjectOwner = _worker.ProjectOwnerDal.Queryable().ToList();

                if (getProjectOwner == null)
                    return new ErrorDataResult<ICollection<ProjectOwner>>(String.Join("-", "Proje bulunamadı"));

                return new SuccessDataResult<ICollection<ProjectOwner>>(getProjectOwner);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ICollection<ProjectOwner>>(ex);
            }
        }
    }
}
