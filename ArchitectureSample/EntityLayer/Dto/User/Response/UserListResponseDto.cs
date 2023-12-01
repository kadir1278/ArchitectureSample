using CoreLayer.DataAccess.Abstract;
using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto.User.Response
{
    public record UserListResponseDto:IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }

        public UserListResponseDto(string name, string surname, string username, string password, string companyName)
        {
            Name = name;
            Surname = surname;
            Username = username;
            Password = password;
            CompanyName = companyName;
        }
    }
}
