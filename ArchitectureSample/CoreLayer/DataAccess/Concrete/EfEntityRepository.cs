using CoreLayer.DataAccess.Abstract;
using CoreLayer.Utilities.Results.Abstract;
using Microsoft.EntityFrameworkCore;
using CoreLayer.Utilities.Results.Concrete;
using CoreLayer.Helper;
using CoreLayer.DataAccess.Constants;

namespace CoreLayer.DataAccess.Concrete
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
                                                       where TEntity : class, IEntity, new()
                                                       where TContext : DbContext
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _entities;
        public EfEntityRepository(TContext context)
        {
            _dbContext = context;
            _entities = _dbContext.Set<TEntity>();
        }

        public IDataResult<TEntity> Add(TEntity entity, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();

            try
            {
                entity = DatabaseModelHelper<TEntity>.ModelCreaterComplete(entity);
                var addedEntity = _entities.Add(entity);
                addedEntity.State = EntityState.Added;
                bool isSaved = _dbContext.SaveChanges() > 0 ? true : false;

                if (!isSaved)
                    return new ErrorDataResult<TEntity>(DatabaseErrorMessage.SaveError);

                return new SuccessDataResult<TEntity>(addedEntity.Entity);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TEntity>(ex);
            }
        }
        public IDataResult<ICollection<TEntity>> AddRange(ICollection<TEntity> addedEntities, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                _entities.AddRange(addedEntities);
                bool isSaved = _dbContext.SaveChanges() > 0 ? true : false;
                if (!isSaved)
                    return new ErrorDataResult<ICollection<TEntity>>(DatabaseErrorMessage.SaveError);
                return new SuccessDataResult<ICollection<TEntity>>(addedEntities);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ICollection<TEntity>>(ex);
            }
        }

        public IDataResult<TEntity> SoftDelete(Guid Id, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                TEntity? entity = _entities.Find(Id);
                if (entity is null)
                    return new ErrorDataResult<TEntity>(DatabaseErrorMessage.NotFound);

                entity.IsDeleted = true;
                var deletedEntity = _entities.Update(entity);
                deletedEntity.State = EntityState.Modified;

                bool isSaved = _dbContext.SaveChanges() > 0 ? true : false;
                if (!isSaved)
                    return new ErrorDataResult<TEntity>(DatabaseErrorMessage.SaveError);

                return new SuccessDataResult<TEntity>(deletedEntity.Entity);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TEntity>(ex);
            }
        }

        public IDataResult<ICollection<TEntity>> SoftDeleteRange(ICollection<TEntity> deletedEntities, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {

                foreach (TEntity deletedEntity in deletedEntities)
                {
                    TEntity entity = DatabaseModelHelper<TEntity>.ModelSoftDeleterComplete(deletedEntity);
                    var deletedEntitie = _entities.Update(entity);
                    deletedEntitie.State = EntityState.Modified;
                }

                bool isSaved = _dbContext.SaveChanges() > 0 ? true : false;
                if (!isSaved)
                    return new ErrorDataResult<ICollection<TEntity>>(DatabaseErrorMessage.SaveError);
                return new SuccessDataResult<ICollection<TEntity>>(deletedEntities);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ICollection<TEntity>>(ex);
            }
        }


        public IDataResult<TEntity> Update(TEntity dto, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                var entity = _entities.Find(dto.Id);
                if (entity is null)
                    return new ErrorDataResult<TEntity>(DatabaseErrorMessage.NotFound);

                TEntity updateEntity = DatabaseModelHelper<TEntity>.ModelUpdaterComplete(entity);
                var updatedEntity = _entities.Update(updateEntity);
                updatedEntity.State = EntityState.Modified;

                bool isSaved = _dbContext.SaveChanges() > 0 ? true : false;
                if (!isSaved)
                    return new ErrorDataResult<TEntity>(DatabaseErrorMessage.SaveError);

                return new SuccessDataResult<TEntity>(updatedEntity.Entity);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TEntity>(ex);
            }
        }

        public IDataResult<ICollection<TEntity>> UpdateRange(ICollection<TEntity> updatedEntities, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                _entities.UpdateRange(updatedEntities);
                bool isSaved = _dbContext.SaveChanges() > 0 ? true : false;
                if (!isSaved)
                    return new ErrorDataResult<ICollection<TEntity>>(DatabaseErrorMessage.SaveError);
                return new SuccessDataResult<ICollection<TEntity>>(updatedEntities);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ICollection<TEntity>>(ex);
            }
        }

        public IQueryable<TEntity> Queryable()
        {
                return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public IDataResult<TEntity> GetById(Guid id)
        {
            try
            {
                TEntity? entity = Queryable().Where(x => x.Id == id).FirstOrDefault();
                if (entity is null) return new ErrorDataResult<TEntity>("Entity Not Found");

                return new SuccessDataResult<TEntity>(entity);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TEntity>(ex);
            }
        }
    }
}
