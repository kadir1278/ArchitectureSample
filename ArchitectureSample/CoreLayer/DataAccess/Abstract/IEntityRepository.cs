using CoreLayer.Utilities.Results.Abstract;

namespace CoreLayer.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity>
    {
        IQueryable<TEntity> Queryable();
        Task<IDataResult<TEntity>> Add(TEntity dto, CancellationToken _cancellationToken);
        Task<IDataResult<ICollection<TEntity>>> AddRange(ICollection<TEntity> addedDtos, CancellationToken _cancellationToken);
        Task<IDataResult<TEntity>> Update(TEntity dto, CancellationToken _cancellationToken);
        Task<IDataResult<ICollection<TEntity>>> UpdateRange(ICollection<TEntity> updatedDtos, CancellationToken _cancellationToken);
        Task<IDataResult<TEntity>> SoftDelete(Guid Id, CancellationToken _cancellationToken);
        Task<IDataResult<ICollection<TEntity>>> SoftDeleteRange(ICollection<TEntity> deletedDtos, CancellationToken _cancellationToken);
        Task<IDataResult<TEntity>> GetById(Guid id);
    }
}
