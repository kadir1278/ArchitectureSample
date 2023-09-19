using CoreLayer.Results.Abstract;

namespace CoreLayer.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity, TDto> 
    {
        IDataResult<IQueryable<TEntity>> GetAllQueryable();
        IDataResult<IQueryable<TEntity>> GetByIdQueryable(int Id);

        IDataResult<TEntity> Add(TDto dto);
        IDataResult<ICollection<TDto>> AddRange(ICollection<TDto> addedDtos);

        IDataResult<TEntity> Update(TDto dto);
        IDataResult<ICollection<TEntity>> UpdateRange(ICollection<TDto> updatedDtos);

        IDataResult<TEntity> Delete(int Id);
        IDataResult<ICollection<TEntity>> DeleteRange(ICollection<TDto> deletedDtos);
    }
}
