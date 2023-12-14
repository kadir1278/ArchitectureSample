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

        public async Task<IDataResult<TEntity>> Add(TEntity entity, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();

            entity = DatabaseModelHelper<TEntity>.ModelCreaterComplete(entity);
            var addedEntity = await _entities.AddAsync(entity, _cancellationToken);
            addedEntity.State = EntityState.Added;
            bool isSaved = await _dbContext.SaveChangesAsync() > 0 ? true : false;

            if (!isSaved)
                return new ErrorDataResult<TEntity>(DatabaseErrorMessage.SaveError);

            return new SuccessDataResult<TEntity>(addedEntity.Entity);
        }
        public async Task<IDataResult<ICollection<TEntity>>> AddRange(ICollection<TEntity> addedEntities, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            await _entities.AddRangeAsync(addedEntities, _cancellationToken);
            bool isSaved = await _dbContext.SaveChangesAsync() > 0 ? true : false;
            if (!isSaved)
                return new ErrorDataResult<ICollection<TEntity>>(DatabaseErrorMessage.SaveError);
            return new SuccessDataResult<ICollection<TEntity>>(addedEntities);
        }

        public async Task<IDataResult<TEntity>> SoftDelete(Guid Id, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            TEntity? entity = await _entities.FindAsync(Id);
            if (entity is null)
                return new ErrorDataResult<TEntity>(DatabaseErrorMessage.NotFound);

            entity.IsDeleted = true;
            var deletedEntity = _entities.Update(entity);
            deletedEntity.State = EntityState.Modified;

            bool isSaved = await _dbContext.SaveChangesAsync() > 0 ? true : false;
            if (!isSaved)
                return new ErrorDataResult<TEntity>(DatabaseErrorMessage.SaveError);

            return new SuccessDataResult<TEntity>(deletedEntity.Entity);
        }

        public async Task<IDataResult<ICollection<TEntity>>> SoftDeleteRange(ICollection<TEntity> deletedEntities, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();

            foreach (TEntity deletedEntity in deletedEntities)
            {
                TEntity entity = DatabaseModelHelper<TEntity>.ModelSoftDeleterComplete(deletedEntity);
                var deletedEntitie = _entities.Update(entity);
                deletedEntitie.State = EntityState.Modified;
            }

            bool isSaved = await _dbContext.SaveChangesAsync() > 0 ? true : false;
            if (!isSaved)
                return new ErrorDataResult<ICollection<TEntity>>(DatabaseErrorMessage.SaveError);
            return new SuccessDataResult<ICollection<TEntity>>(deletedEntities);
        }


        public async Task<IDataResult<TEntity>> Update(TEntity dto, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            var entity = await _entities.FindAsync(dto.Id);
            if (entity is null)
                return new ErrorDataResult<TEntity>(DatabaseErrorMessage.NotFound);

            TEntity updateEntity = DatabaseModelHelper<TEntity>.ModelUpdaterComplete(entity);
            var updatedEntity = _entities.Update(updateEntity);
            updatedEntity.State = EntityState.Modified;

            bool isSaved = await _dbContext.SaveChangesAsync() > 0 ? true : false;
            if (!isSaved)
                return new ErrorDataResult<TEntity>(DatabaseErrorMessage.SaveError);

            return new SuccessDataResult<TEntity>(updatedEntity.Entity);
        }

        public async Task<IDataResult<ICollection<TEntity>>> UpdateRange(ICollection<TEntity> updatedEntities, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            _entities.UpdateRange(updatedEntities);
            bool isSaved = await _dbContext.SaveChangesAsync() > 0 ? true : false;
            if (!isSaved)
                return new ErrorDataResult<ICollection<TEntity>>(DatabaseErrorMessage.SaveError);
            return new SuccessDataResult<ICollection<TEntity>>(updatedEntities);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<IDataResult<TEntity>> GetById(Guid id)
        {
            TEntity? entity = await Queryable().Where(x => x.Id == id).FirstOrDefaultAsync<TEntity>();
            if (entity is null) return new ErrorDataResult<TEntity>("Entity Not Found");

            return new SuccessDataResult<TEntity>(entity);
        }
    }
}
