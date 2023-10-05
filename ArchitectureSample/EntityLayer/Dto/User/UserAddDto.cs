﻿using EntityLayer.Base;

namespace EntityLayer.Dto.User
{
    public class UserAddDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
