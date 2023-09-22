using CoreLayer.Results.Abstract;

namespace CoreLayer.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity, TDto> 
    {
        IDataResult<IQueryable<TEntity>> GetAllQueryable(CancellationToken _cancellationToken);
        IDataResult<IQueryable<TEntity>> GetByIdQueryable(int Id, CancellationToken _cancellationToken);

        IDataResult<TEntity> Add(TDto dto, CancellationToken _cancellationToken);
        IDataResult<ICollection<TDto>> AddRange(ICollection<TDto> addedDtos, CancellationToken _cancellationToken);

        IDataResult<TEntity> Update(TDto dto, CancellationToken _cancellationToken);
        IDataResult<ICollection<TEntity>> UpdateRange(ICollection<TDto> updatedDtos, CancellationToken _cancellationToken);

        IDataResult<TEntity> Delete(int Id, CancellationToken _cancellationToken);
        IDataResult<ICollection<TEntity>> DeleteRange(ICollection<TDto> deletedDtos, CancellationToken _cancellationToken);
    }
}
