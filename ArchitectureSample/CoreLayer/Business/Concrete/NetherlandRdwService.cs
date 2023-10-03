using CoreLayer.Business.Abstract;
using CoreLayer.Entity.ViewModel.NetherlandRdwServiceViewModel;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using Newtonsoft.Json;

namespace CoreLayer.Business.Concrete
{
    public class NetherlandRdwService : INetherlandRdwService
    {
        public IDataResult<GetInfoByPlateViewModel> GetInfoByPlate(string plate)
        {
            try
            {
                plate = plate.ToUpper().Replace("-", "");
                string returnJsonObject;
                GetInfoByPlateViewModel returnModel;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri($"https://opendata.rdw.nl/resource/m9d7-ebf2.json?kenteken={plate}");

                    var result = httpClient.GetAsync(httpClient.BaseAddress).Result;
                    if (!result.IsSuccessStatusCode) return new ErrorDataResult<GetInfoByPlateViewModel>("RDW Connection Failed");

                    returnJsonObject = result.Content.ReadAsStringAsync().Result;
                    returnModel = JsonConvert.DeserializeObject<List<GetInfoByPlateViewModel>>(returnJsonObject).FirstOrDefault();
                }

                if (returnModel == null)
                    return new ErrorDataResult<GetInfoByPlateViewModel>("Plate Info Not Found");

                return new SuccessDataResult<GetInfoByPlateViewModel>(returnModel);
            }
           catch (Exception ex)
            {
                return new ErrorDataResult<GetInfoByPlateViewModel>(ex);
            }
        }
    }
}
