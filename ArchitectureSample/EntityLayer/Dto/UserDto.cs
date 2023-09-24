using EntityLayer.Base;

namespace EntityLayer.Dto
{
    public class UserDto : BaseDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

    }
}
