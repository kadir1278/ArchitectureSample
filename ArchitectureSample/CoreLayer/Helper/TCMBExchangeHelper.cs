using CoreLayer.Entity.Dto.ExhangeServiceViewModel;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using System.Xml;

namespace CoreLayer.Helper
{
    public static class TCMBExchangeHelper
    {
        public static IDataResult<List<GetAllExchangeViewModel>> GetAllTcmbExchanges()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ConfigurationHelper.GetTcmbExchangeUrl());

                List<GetAllExchangeViewModel> exchangeResponseDtoList = new();

                exchangeResponseDtoList.Add(new GetAllExchangeViewModel
                {
                    CurrencyCode = "TRY",
                    Currency = "TURK LIRASI"
                });

                foreach (XmlNode node in xmlDoc.SelectNodes("Tarih_Date")[0].ChildNodes)
                {
                    exchangeResponseDtoList.Add(new GetAllExchangeViewModel()
                    {
                        CurrencyCode = node.Attributes["Kod"].Value.Trim(),
                        Currency = node["Isim"].InnerText.Trim(),
                        Unit = int.Parse(node["Unit"].InnerText),
                        ForexBuying = Convert.ToDecimal(node["ForexBuying"].InnerText.Replace(".", ",").PadLeft(2, '0')),
                        ForexSelling = Convert.ToDecimal(node["ForexSelling"].InnerText.Replace(".", ",").PadLeft(2, '0')),
                        BanknoteBuying = Convert.ToDecimal(node["BanknoteBuying"].InnerText.Replace(".", ",").PadLeft(2, '0')),
                        BanknoteSelling = Convert.ToDecimal(node["BanknoteSelling"].InnerText.Replace(".", ",").PadLeft(2, '0'))
                    });
                }

                return new SuccessDataResult<List<GetAllExchangeViewModel>>(exchangeResponseDtoList.OrderBy(x => x.Currency).ToList());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<GetAllExchangeViewModel>>(ex);
            }
        }

    }
}
