﻿using CoreLayer.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Business.Abstract
{
    public interface INetherlandRdwService
    {
        public IDataResult<object> GetInfoByPlate(string plate);
    }
}
