using EntityLayer.Base;

namespace EntityLayer.Dto
{
    public class UserDto : BaseDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public UserDto(string username, string password, bool isactive = false)
        {
            this.Username = username;
            this.Password = password;
            this.IsActive = isactive;
        }

    }
}
