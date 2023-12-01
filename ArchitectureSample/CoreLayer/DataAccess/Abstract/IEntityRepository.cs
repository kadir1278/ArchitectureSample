using CoreLayer.Utilities.Results.Abstract;

namespace CoreLayer.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> 
    {
        IQueryable<TEntity> Queryable();
        IDataResult<TEntity> Add(TEntity dto, CancellationToken _cancellationToken);
        IDataResult<ICollection<TEntity>> AddRange(ICollection<TEntity> addedDtos, CancellationToken _cancellationToken);
        IDataResult<TEntity> Update(TEntity dto, CancellationToken _cancellationToken);
        IDataResult<ICollection<TEntity>> UpdateRange(ICollection<TEntity> updatedDtos, CancellationToken _cancellationToken);
        IDataResult<TEntity> SoftDelete(Guid Id, CancellationToken _cancellationToken);
        IDataResult<ICollection<TEntity>> SoftDeleteRange(ICollection<TEntity> deletedDtos, CancellationToken _cancellationToken);
        IDataResult<TEntity> GetById(Guid id);
    }
}
