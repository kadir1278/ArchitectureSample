using CoreLayer.Entity.Dto.ExhangeServiceDto;
using CoreLayer.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Business.Abstract
{
    public interface ITCMBExchangeService
    {
        public IDataResult<List<GetAllExchangeViewModel>> GetAllTcmbExchanges();
    }
}
