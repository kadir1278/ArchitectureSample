using CoreLayer.Utilities.Results.Abstract;

namespace CoreLayer.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity, TAddDto, TUpdateDto, TGetDto> 
    {
        IQueryable<TEntity> Queryable();
        IQueryable<TEntity> QueryableGlobalFilter();
        IDataResult<TEntity> Add(TAddDto dto, CancellationToken _cancellationToken);
        IDataResult<ICollection<TEntity>> AddRange(ICollection<TAddDto> addedDtos, CancellationToken _cancellationToken);
        IDataResult<TEntity> Update(TUpdateDto dto, CancellationToken _cancellationToken);
        IDataResult<ICollection<TEntity>> UpdateRange(ICollection<TUpdateDto> updatedDtos, CancellationToken _cancellationToken);
        IDataResult<TEntity> SoftDelete(Guid Id, CancellationToken _cancellationToken);
        IDataResult<ICollection<TEntity>> SoftDeleteRange(ICollection<TGetDto> deletedDtos, CancellationToken _cancellationToken);
        IDataResult<TGetDto> GetById(Guid id);
    }
}
