using CoreLayer.DataAccess.Abstract;
using Mapster;

namespace CoreLayer.Helper
{
    public static class DatabaseModelHelper<TEntity, TDto>
                                                       where TEntity : class, IEntity, new()
                                                       where TDto : class, IDto, new()

    {
        public static TEntity ModelCreaterComplete(TDto dto)
        {
            var _loginUser = Guid.NewGuid();
            TEntity entity = dto.Adapt<TEntity>();
            entity.Id = Guid.NewGuid();
            entity.UpdatedDate = DateTime.UtcNow;
            entity.CreatedDate = DateTime.UtcNow;
            entity.IsDeleted = false;
            entity.IsActive = true;
            entity.UpdatedBy = _loginUser;
            entity.CreatedBy = _loginUser;
            return entity;
        }
        public static TEntity ModelUpdaterComplete(TDto dto)
        {
            var _loginUser = Guid.NewGuid();
            TEntity entity = dto.Adapt<TEntity>();
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = _loginUser;
            return entity;
        }
        public static TEntity ModelSoftDeleterComplete(TDto dto)
        {
            var _loginUser = Guid.NewGuid();
            TEntity entity = dto.Adapt<TEntity>();
            entity.Id = Guid.NewGuid();
            entity.UpdatedDate = DateTime.UtcNow;
            entity.IsDeleted = true;
            entity.UpdatedBy = _loginUser;
            return entity;
        }

    }
}
