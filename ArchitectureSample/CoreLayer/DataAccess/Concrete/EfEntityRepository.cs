using CoreLayer.DataAccess.Abstract;
using CoreLayer.Utilities.Results.Abstract;
using Microsoft.EntityFrameworkCore;
using Mapster;
using CoreLayer.Utilities.Results.Concrete;
using CoreLayer.Helper;
using CoreLayer.DataAccess.Constants;

namespace CoreLayer.DataAccess.Concrete
{
    public class EfEntityRepository<TEntity, TAddDto, TUpdateDto, TGetDto, TContext> : IEntityRepository<TEntity, TAddDto, TUpdateDto, TGetDto>
                                                       where TEntity : class, IEntity, new()
                                                       where TAddDto : class, IDto, new()
                                                       where TUpdateDto : class, IDto, new()
                                                       where TGetDto : class, IDto, new()
                                                       where TContext : DbContext
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _entities;
        public EfEntityRepository(TContext context)
        {
            _dbContext = context;
            _entities = _dbContext.Set<TEntity>();
        }

        public IDataResult<TEntity> Add(TAddDto dto, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();

            try
            {
                TEntity entity = DatabaseModelHelper<TEntity, TAddDto>.ModelCreaterComplete(dto);
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
        public IDataResult<ICollection<TEntity>> AddRange(ICollection<TAddDto> addedDtos, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                ICollection<TEntity> addedEntities = new List<TEntity>();
                foreach (TAddDto dto in addedDtos)
                {

                    TEntity entity = DatabaseModelHelper<TEntity, TAddDto>.ModelCreaterComplete(dto);
                    var addedEntity = _entities.Add(entity);
                    addedEntity.State = EntityState.Added;
                    addedEntities.Add(entity);
                }

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
                TEntity entity = _entities.Find(Id);
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

        public IDataResult<ICollection<TEntity>> SoftDeleteRange(ICollection<TGetDto> deletedDtos, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                ICollection<TEntity> deletedEntities = new List<TEntity>();
                foreach (TGetDto dto in deletedDtos)
                {

                    TEntity entity = DatabaseModelHelper<TEntity, TGetDto>.ModelSoftDeleterComplete(dto);
                    var deletedEntity = _entities.Update(entity);
                    deletedEntity.State = EntityState.Modified;
                    deletedEntities.Add(entity);
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


        public IDataResult<TEntity> Update(TUpdateDto dto, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                TEntity entity = _entities.Find(dto.Id);
                if (entity is null)
                    return new ErrorDataResult<TEntity>(DatabaseErrorMessage.NotFound);
                entity = dto.Adapt<TEntity>();
                entity = DatabaseModelHelper<TEntity, TUpdateDto>.ModelUpdaterComplete(dto);
                var updatedEntity = _entities.Update(entity);
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

        public IDataResult<ICollection<TEntity>> UpdateRange(ICollection<TUpdateDto> updatedDtos, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                ICollection<TEntity> updatedEntities = new List<TEntity>();
                foreach (TUpdateDto dto in updatedDtos)
                {

                    TEntity entity = _entities.Find(dto.Id);
                    if (entity is null)
                        return new ErrorDataResult<ICollection<TEntity>>(DatabaseErrorMessage.NotFound);

                    entity = DatabaseModelHelper<TEntity, TUpdateDto>.ModelUpdaterComplete(dto);
                    var updatedEntity = _entities.Update(entity);
                    updatedEntity.State = EntityState.Modified;

                }

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
        public IQueryable<TEntity> Queryable() => _dbContext.Set<TEntity>().AsNoTracking();

     
    }
}
