﻿using CoreLayer.Business.Abstract;
using CoreLayer.Entity.Dto.ExhangeServiceViewModel;
using CoreLayer.Helper;
using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CoreLayer.Business.Concrete
{
    public class TCMBExchangeService : ITCMBExchangeService
    {
        private readonly string _baseUrl = ConfigurationHelper.GetTcmbExchangeUrl();
        public IDataResult<List<GetAllExchangeViewModel>> GetAllTcmbExchanges()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(_baseUrl);

                List<GetAllExchangeViewModel> exchangeResponseDtoList = new();

                exchangeResponseDtoList.Add(new GetAllExchangeViewModel
                {
                    CurrencyCode = "TRY",
                    Currency = "TÜRK LİRASI"
                });

                foreach (XmlNode node in xmlDoc.SelectNodes("Tarih_Date")[0].ChildNodes)
                {
                    exchangeResponseDtoList.Add(new GetAllExchangeViewModel()
                    {
                        CurrencyCode = node.Attributes["Kod"].Value.Trim(),
                        Currency = node["Isim"].InnerText.Trim(),
                        Unit = int.Parse(node["Unit"].InnerText),
                        ForexBuying = Convert.ToDecimal(node["ForexBuying"].InnerText.Replace(".", ",") != string.Empty ? node["ForexBuying"].InnerText.Replace(".", ",") : "0"),
                        ForexSelling = Convert.ToDecimal(node["ForexSelling"].InnerText.Replace(".", ",") != string.Empty ? node["ForexSelling"].InnerText.Replace(".", ",") : "0"),
                        BanknoteBuying = Convert.ToDecimal(node["BanknoteBuying"].InnerText.Replace(".", ",") != string.Empty ? node["BanknoteBuying"].InnerText.Replace(".", ",") : "0"),
                        BanknoteSelling = Convert.ToDecimal(node["BanknoteSelling"].InnerText.Replace(".", ",") != string.Empty ? node["BanknoteSelling"].InnerText.Replace(".", ",") : "0")
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