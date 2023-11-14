using CoreLayer.Entity.Dto.ExhangeServiceViewModel;
using CoreLayer.Utilities.Results.Abstract;

namespace IntegrationLayer.Business.Abstract
{
    public interface ITCMBExchangeService
    {
        public IDataResult<List<GetAllExchangeViewModel>> GetAllTcmbExchanges();
    }
}
