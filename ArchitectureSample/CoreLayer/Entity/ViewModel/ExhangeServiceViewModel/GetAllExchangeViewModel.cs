using CoreLayer.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entity.Dto.ExhangeServiceViewModel
{
    public class GetAllExchangeViewModel
    {
        public string CurrencyCode { get; set; }
        public string Currency { get; set; }
        public int Unit { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
        public decimal BanknoteBuying { get; set; }
        public decimal BanknoteSelling { get; set; }
    }
}
