using CoreLayer.Business.Abstract;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreLayer.Business.Concrete
{
    public class NetherlandRdwService : INetherlandRdwService
    {
        public IDataResult<object> GetInfoByPlate(string plate)
        {
            try
            {
                plate = plate.ToUpper().Replace("-", "");
                string returnJsonObject;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri($"https://opendata.rdw.nl/resource/m9d7-ebf2.json?kenteken={plate}");

                    var result = httpClient.GetAsync(httpClient.BaseAddress).Result;
                    if (!result.IsSuccessStatusCode) return new ErrorDataResult<object>("RDW Connection Failed");

                    returnJsonObject = result.Content.ReadAsStringAsync().Result;
                }
                return new SuccessDataResult<object>(returnJsonObject);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<object>(ex);
            }
        }
    }
}
