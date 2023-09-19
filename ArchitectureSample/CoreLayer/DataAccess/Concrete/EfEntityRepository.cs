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
        private readonly CancellationToken _cancellationToken;
        public EfEntityRepository(TContext context, CancellationToken cancellationToken)
        {
            _dbContext = context;
            _cancellationToken = cancellationToken;
        }

        public IDataResult<TEntity> Add(TDto dto)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<ICollection<TDto>> AddRange(ICollection<TDto> addedDtos)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<TEntity> Delete(int Id)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<ICollection<TEntity>> DeleteRange(ICollection<TDto> deletedDtos)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<IQueryable<TEntity>> GetAllQueryable()
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                IQueryable<TEntity> result = _dbContext.Set<TEntity>()
                                                                       .AsNoTracking()
                                                                       .Where(x => x.IsActive
                                                                                && !x.IsDeleted);
                return new SuccessDataResult<IQueryable<TEntity>>(result);

            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IQueryable<TEntity>>(exception);
            }
        }

        public IDataResult<IQueryable<TEntity>> GetByIdQueryable(int Id)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            try
            {
                IQueryable<TEntity> result = _dbContext.Set<TEntity>()
                                                       .AsNoTracking()
                                                       .Where(x => x.Id == Id
                                                                && x.IsActive
                                                                && !x.IsDeleted);

                return new SuccessDataResult<IQueryable<TEntity>>(result);

            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IQueryable<TEntity>>(exception);
            }
        }

        public IDataResult<TEntity> Update(TDto dto)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }

        public IDataResult<ICollection<TEntity>> UpdateRange(ICollection<TDto> updatedDtos)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            throw new NotImplementedException();
        }
    }
}
