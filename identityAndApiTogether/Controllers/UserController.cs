using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using againAndAgainWhenWillYouStop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace againAndAgainWhenWillYouStop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager,RoleManager<ApplicationRole> roleManager){
            _userManager = userManager;
            _roleManager = roleManager;
        }

        
        public async Task<IActionResult> Login(LoginViewModel model){

            ApplicationUser user = await _userManager.FindByNameAsync(model.UserName);

            if(user != null && await _userManager.CheckPasswordAsync(user,model.Password)){


                var claims = new[]{

                    new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));

                var token = new JwtSecurityToken(
                    issuer : "http://google.com",
                    audience : "http://google.com",
                    expires : DateTime.UtcNow.AddHours(1),
                    claims:claims,
                    signingCredentials : new SigningCredentials(signinKey,SecurityAlgorithms.HmacSha256)
                );

                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });


            }

            return BadRequest("işlem başarısız");

        }


        public async Task<IActionResult> UserCreate(UserCreateViewModel userCreateView){

            ApplicationUser user = new ApplicationUser();
            user.Email = userCreateView.Email;
            user.UserName = userCreateView.UserName;

            var result = await _userManager.CreateAsync(user,userCreateView.Password);

            if(result.Succeeded){

                if(!_roleManager.RoleExistsAsync("User").Result){

                    ApplicationRole role = new ApplicationRole();
                    role.Name = "User";


                    var roleResult = await _roleManager.CreateAsync(role);

                    if(roleResult.Succeeded){
                        
                        _userManager.AddToRoleAsync(user,"User").Wait();

                    }

                }

                _userManager.AddToRoleAsync(user,"User").Wait();
                return Ok();
            }

            return BadRequest("kullanici olustururken hata oldu");

        }


    }
}