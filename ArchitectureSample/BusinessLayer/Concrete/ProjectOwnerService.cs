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
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly CancellationToken _ct;

        public ProjectOwnerService(IWorker worker, IHttpContextAccessor contextAccessor)
        {
            _worker = worker;
            _contextAccessor = contextAccessor;
        }

        public IDataResult<bool> ActiveStatusToProjectOwner(Guid projectOwnerId)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                ProjectOwner? getProjectOwnerByGuid = _worker.ProjectOwnerDal.Queryable()
                                                                   .Where(x => x.Id == projectOwnerId)
                                                                   .First();

                if (getProjectOwnerByGuid == null)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<bool>("Proje bulunamadı");
                }

                var projectOwnerUpdateDto = getProjectOwnerByGuid.Adapt<ProjectOwnerUpdateDto>();
                projectOwnerUpdateDto.IsActive = true;
                var updatedProjectOwner = _worker.ProjectOwnerDal.Update(projectOwnerUpdateDto, _ct);

                if (!updatedProjectOwner.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<bool>(String.Join("-", updatedProjectOwner.Messages));
                }
                _worker.CommitAndSaveChanges();
                return new SuccessDataResult<bool>(true);
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<bool>(ex);
            }
        }

        public IDataResult<ProjectOwner> AddProjectOwner(ProjectOwnerAddDto projectOwnerAddDto)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();

                bool checkDomain = _worker.ProjectOwnerDal.Queryable().Where(x => x.Domain == projectOwnerAddDto.Domain).Count() != 1;
                if (!checkDomain)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<ProjectOwner>("Domain registered");
                }

                IDataResult<ProjectOwner> addedProjectOwner = _worker.ProjectOwnerDal.Add(projectOwnerAddDto, _ct);

                if (!addedProjectOwner.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<ProjectOwner>(String.Join("-", addedProjectOwner.Messages));
                }
                _worker.CommitAndSaveChanges();
                return addedProjectOwner;
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<ProjectOwner>(ex);
            }
        }

        public IDataResult<bool> DeactiveStatusToProjectOwner(Guid projectOwnerId)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                ProjectOwner? getProjectOwnerByGuid = _worker.ProjectOwnerDal.Queryable()
                                                                   .Where(x => x.Id == projectOwnerId)
                                                                   .First();

                if (getProjectOwnerByGuid == null)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<bool>("Proje bulunamadı");
                }

                var projectOwnerUpdateDto = getProjectOwnerByGuid.Adapt<ProjectOwnerUpdateDto>();
                projectOwnerUpdateDto.IsActive = false;
                var updatedProjectOwner = _worker.ProjectOwnerDal.Update(projectOwnerUpdateDto, _ct);

                if (!updatedProjectOwner.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<bool>(String.Join("-", updatedProjectOwner.Messages));
                }
                _worker.CommitAndSaveChanges();
                return new SuccessDataResult<bool>(true);
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<bool>(ex);
            }
        }

        public IDataResult<bool> DeleteProjectOwner(Guid projectOwnerId)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                _worker.StartTransaction();
                var deletedProjectOwner = _worker.ProjectOwnerDal.SoftDelete(projectOwnerId, _ct);

                if (!deletedProjectOwner.IsSuccess)
                {
                    _worker.RollbackTransaction();
                    return new ErrorDataResult<bool>(String.Join("-", deletedProjectOwner.Messages));
                }
                _worker.CommitAndSaveChanges();
                return new SuccessDataResult<bool>(true);
            }
            catch (Exception ex)
            {
                _worker.RollbackTransaction();
                return new ErrorDataResult<bool>(ex);
            }
        }

        public IDataResult<ProjectOwner> GetProjectOwner(Guid projectOwnerId)
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
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
        public IDataResult<ProjectOwner> GetProjectOwnerByRequestDomain()
        {
            try
            {
                _ct.ThrowIfCancellationRequested();
                var getProjectOwner = _worker.ProjectOwnerDal.Queryable()
                                                             .Where(x => x.Domain == _contextAccessor.HttpContext.Request.Host.ToString())
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
                _ct.ThrowIfCancellationRequested();
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
