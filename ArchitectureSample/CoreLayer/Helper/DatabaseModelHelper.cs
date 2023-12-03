using CoreLayer.DataAccess.Abstract;

namespace CoreLayer.Helper
{
    public static class DatabaseModelHelper<TEntity>where TEntity : class, IEntity,new()

    {
        public static TEntity ModelCreaterComplete( TEntity entity)
        {
            var _loginUser = Guid.NewGuid();
            entity.Id = Guid.NewGuid();
            entity.UpdatedDate = DateTime.UtcNow;
            entity.CreatedDate = DateTime.UtcNow;
            entity.IsDeleted = false;
            entity.IsActive = true;
            entity.UpdatedBy = _loginUser;
            entity.CreatedBy = _loginUser;
            return entity;
        }
        public static TEntity ModelUpdaterComplete(TEntity entity)
        {
            var _loginUser = Guid.NewGuid();
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedBy = _loginUser;
            return entity;
        }
        public static TEntity ModelSoftDeleterComplete(TEntity entity)
        {
            var _loginUser = Guid.NewGuid();
            entity.Id = Guid.NewGuid();
            entity.UpdatedDate = DateTime.UtcNow;
            entity.IsDeleted = true;
            entity.UpdatedBy = _loginUser;
            return entity;
        }

    }
}
