using CoreLayer.Entity.ViewModel.NetherlandRdwServiceViewModel;
using CoreLayer.Utilities.Results.Abstract;

namespace IntegrationLayer.Business.Abstract
{
    public interface INetherlandRdwService
    {
        public IDataResult<GetInfoByPlateViewModel> GetInfoByPlate(string plate);
    }
}
