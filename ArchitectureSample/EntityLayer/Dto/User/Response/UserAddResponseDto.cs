using CoreLayer.DataAccess.Abstract;
using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto.User.Response
{
    public record UserAddResponseDto : IDto
    {
        public string Username { get; set; }

        public UserAddResponseDto(string username)
        {
            Username = username;
        }
    }
}
