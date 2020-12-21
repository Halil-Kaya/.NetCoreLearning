using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using UdemyAndroidKotlin.Auth.Dtos;
using UdemyAndroidKotlin.Auth.Models;
using static IdentityServer4.IdentityServerConstants;

namespace UdemyAndroidKotlin.Auth.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }


        public IActionResult Test()
        {
            return Ok("test ok");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {

            ApplicationUser user = new ApplicationUser();

            user.UserName = signUpViewModel.UserName;
            user.Email = signUpViewModel.Email;

            user.City = signUpViewModel.City;

            var result = await _userManager.CreateAsync(user,signUpViewModel.Password);

            if (result.Succeeded)
            {
                //hata mesajı donecek
                return BadRequest();
            }


            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> GetUser()
        {

            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if(userIdClaim == null)
            {
                return BadRequest();
            }


            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            
            if(user == null)
            {
                return BadRequest();
            }


            var userDto = new ApplicationUserDto() {
                
                UserName = user.UserName,
                Email = user.Email,
                City = user.City
            
            };


            return Ok(userDto);
        }

    }
}
