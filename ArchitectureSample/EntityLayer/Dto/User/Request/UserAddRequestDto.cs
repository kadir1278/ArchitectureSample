﻿using CoreLayer.DataAccess.Abstract;

namespace EntityLayer.Dto.User.Request
{
    public record UserAddRequestDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserAddRequestDto(string name, string surname, string username, string password)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
        }
    }
}
