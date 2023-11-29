﻿using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto.ValidationRule
{
    public class ValidationRuleAddDto: BaseDto
    {
        public string ValidatorName { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }

    }
}
