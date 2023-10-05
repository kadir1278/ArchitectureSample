using CoreLayer.DataAccess.Abstract;
using CoreLayer.Utilities.Results.Abstract;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using CoreLayer.Utilities.Results.Concrete;
using System.Collections.Generic;
using CoreLayer.Helper;
using CoreLayer.IoC;
using Microsoft.Extensions.DependencyInjection;

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
                TEntity entity = ModelCreaterComplete(dto);
                var addedEntity = _entities.Add(entity);
                addedEntity.State = EntityState.Added;
                bool isSaved = _dbContext.SaveChanges() > 0 ? true : false;

                if (!isSaved)
                    return new ErrorDataResult<TEntity>("save error");

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

                    TEntity entity = ModelCreaterComplete(dto);
                    var addedEntity = _entities.Add(entity);
                    addedEntity.State = EntityState.Added;
                    addedEntities.Add(entity);
                }

                bool isSaved = _dbContext.SaveChanges() > 0 ? true : false;
                if (!isSaved)
                    return new ErrorDataResult<ICollection<TEntity>>("save error");
                return new SuccessDataResult<ICollection<TEntity>>(addedEntities);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ICollection<TEntity>>(ex);
            }
        }

        public IDataResult<TEntity> SoftDelete(int Id, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                TEntity entity = _entities.Find(Id);
                if (entity == null)
                    return new ErrorDataResult<TEntity>("delete error");

                entity.IsDeleted = true;
                var deletedEntity = _entities.Update(entity);
                deletedEntity.State = EntityState.Modified;

                bool isSaved = _dbContext.SaveChanges() > 0 ? true : false;
                if (!isSaved)
                    return new ErrorDataResult<TEntity>("save error");

                return new SuccessDataResult<TEntity>(deletedEntity.Entity);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TEntity>(ex);
            }
        }

        public IDataResult<ICollection<TEntity>> DeleteRange(ICollection<TGetDto> deletedDtos, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }


        public IDataResult<TEntity> Update(TUpdateDto dto, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<ICollection<TEntity>> UpdateRange(ICollection<TUpdateDto> updatedDtos, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }
        public IQueryable<TEntity> Queryable() => _dbContext.Set<TEntity>().AsNoTracking();

        private TEntity ModelCreaterComplete(TAddDto dto)
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
    }
}
