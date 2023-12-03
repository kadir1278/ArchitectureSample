using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.ValidationRule.Response
{
    public record ValidationRuleListResponseDto : IDto
    {
        public string ValidatorName { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }

        
        public ValidationRuleListResponseDto(string validatorName, string key, string value, string message)
        {
            ValidatorName = validatorName;
            Key = key;
            Value = value;
            Message = message;
        }
    }
}
