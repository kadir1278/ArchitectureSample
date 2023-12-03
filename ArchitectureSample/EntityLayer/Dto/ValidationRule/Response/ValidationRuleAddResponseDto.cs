using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.ValidationRule.Response
{
    public record ValidationRuleAddResponseDto : IDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Message { get; set; }
        public ValidationRuleAddResponseDto(string key, string value, string message)
        {
            Key = key;
            Value = value;
            Message = message;
        }
    }
}
