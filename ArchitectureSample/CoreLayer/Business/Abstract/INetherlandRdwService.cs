using CoreLayer.Entity.ViewModel.NetherlandRdwServiceViewModel;
using CoreLayer.Utilities.Results.Abstract;

namespace CoreLayer.Business.Abstract
{
    public interface INetherlandRdwService
    {
        public IDataResult<GetInfoByPlateViewModel> GetInfoByPlate(string plate);
    }
}
