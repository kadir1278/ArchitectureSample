using CoreLayer.DataAccess.Abstract;
using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto.ValidationRule.Request
{
    public record ValidationRuleAddRequestDto : IDto
    {
        public string ValidatorName { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }

        public ValidationRuleAddRequestDto(string validatorName, string key, string value, string message)
        {
            ValidatorName = validatorName;
            Key = key;
            Value = value;
            Message = message;
        }
    }
}
