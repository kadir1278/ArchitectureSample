using EntityLayer.Base;

namespace EntityLayer.Dto.User
{
    public class UserUpdateDto : BaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
