using CoreLayer.DataAccess.Abstract;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoreLayer.DataAccess.Concrete
{
    public class EfEntityRepository<TEntity, TDto, TContext> : IEntityRepository<TEntity, TDto>
                                                       where TEntity : class, IEntity, new()
                                                       where TDto : class, IDto, new()
                                                       where TContext : DbContext, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _entities;
        public EfEntityRepository(TContext context)
        {
            _dbContext = context;
            _entities = _dbContext.Set<TEntity>();
        }

        public IDataResult<TEntity> Add(TDto dto,CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<ICollection<TDto>> AddRange(ICollection<TDto> addedDtos, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<TEntity> Delete(int Id, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<ICollection<TEntity>> DeleteRange(ICollection<TDto> deletedDtos, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<IQueryable<TEntity>> GetAllQueryable( CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                IQueryable<TEntity> result = _entities.AsNoTracking()
                                                      .Where(x => !x.IsDeleted);
                return new SuccessDataResult<IQueryable<TEntity>>(result);

            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IQueryable<TEntity>>(exception);
            }
        }

        public IDataResult<IQueryable<TEntity>> GetByIdQueryable(int Id, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                IQueryable<TEntity> result = _entities.AsNoTracking()
                                                      .Where(x => x.Id == Id
                                                                && !x.IsDeleted);

                return new SuccessDataResult<IQueryable<TEntity>>(result);

            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IQueryable<TEntity>>(exception);
            }
        }

        public IDataResult<TEntity> Update(TDto dto, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<ICollection<TEntity>> UpdateRange(ICollection<TDto> updatedDtos, CancellationToken _cancellationToken)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }
    }
}
