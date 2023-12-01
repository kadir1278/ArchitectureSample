using CoreLayer.Entity.Dto.ExhangeServiceViewModel;
using CoreLayer.Utilities.Results.Abstract;

namespace CoreLayer.Business.Abstract
{
    public interface ITCMBExchangeService
    {
        public IDataResult<List<GetAllExchangeViewModel>> GetAllTcmbExchanges();
    }
}
