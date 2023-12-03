using CoreLayer.Entity.ViewModel.NetherlandRdwServiceViewModel;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using Newtonsoft.Json;

namespace CoreLayer.Helper
{
    public static class NetherlandRdwHelper
    {
        public static IDataResult<GetInfoByPlateViewModel> GetInfoByPlate(string plate)
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

                if (returnModel is null)
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
