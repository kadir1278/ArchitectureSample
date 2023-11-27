﻿using BusinessLayer.Abstract;
using EntityLayer.Dto.User;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("list-user")]
        public object ListUser() => _userService.GetUserCollection();

        [HttpPost("add-user")]
        public object AddUser(UserAddDto model) => _userService.AddUser(model);
    }
}
