using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyApiWithToken.Domain.Model;
using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Resources;

namespace UdemyApiWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        
        public UserController(IUserService userService,IMapper mapper){
            this._userService = userService;
            this._mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUser(){

            IEnumerable<Claim> claims = User.Claims;

            string userId = claims.Where(c => c.Type == ClaimTypes.NameIdentifier).First().Value;

            UserResponse userResponse = this._userService.FindById(int.Parse(userId));


            if(userResponse.Success){

                return Ok(userResponse.user);

            }

            return BadRequest(userResponse.Message);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddUser(UserResource userResource){

            User user = this._mapper.Map<UserResource,User>(userResource);

            System.Console.WriteLine(user.RefreshTokenEndDate);

            UserResponse userResponse = this._userService.AddUser(user);

            if(userResponse.Success){

                return Ok(userResponse.user);

            }

            return BadRequest(userResponse.Message);

        }

    }
}