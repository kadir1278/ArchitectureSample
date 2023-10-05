using CoreLayer.Entity.ViewModel.NetherlandRdwServiceViewModel;
using CoreLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Business.Abstract
{
    public interface INetherlandRdwService
    {
        public IDataResult<GetInfoByPlateViewModel> GetInfoByPlate(string plate);
    }
}
