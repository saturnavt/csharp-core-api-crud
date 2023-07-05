﻿using Microsoft.AspNetCore.Mvc;
using Services;
using Microsoft.AspNetCore.Authorization;
using Dto;
using Models;
using Responses;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
    {

        [HttpPost(Name = "PostUser")]
        public async Task<UserLoginResponseObject> Post(UserDto users)
        {
            UsersService usersService = new();
            return await usersService.UsersCreate(users);
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<List<UsersModel>> Get()
        {
            UsersService usersService = new();
            return await usersService.Get();
        }

        [HttpPost("login"), AllowAnonymous]
        public async Task<ActionResult<UserLoginResponseObject>> Login(UserLoginDto user)
        {
            UsersService usersService = new();
            return await usersService.GetOne(user);
        }
    }
}
