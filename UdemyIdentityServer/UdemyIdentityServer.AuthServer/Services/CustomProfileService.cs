using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UdemyIdentityServer.AuthServer.Repository;

namespace UdemyIdentityServer.AuthServer.Services
{
    public class CustomProfileService : IProfileService
    {

        private readonly ICustomUserRepository _customUserRepository;

        public CustomProfileService(ICustomUserRepository customUserRepository)
        {
            this._customUserRepository = customUserRepository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {

            var subId = context.Subject.GetSubjectId();

            var user = await _customUserRepository.FindById(int.Parse(subId));

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Emai),
                new Claim("name",user.UserName),
                new Claim("city",user.City),
            };

            if(user.id == 1)
            {

                claims.Add(new Claim("role", "admin"));
                claims.Add(new Claim("role", "customer"));
                claims.Add(new Claim("poke", "topu"));

            }
            else
            {
                claims.Add(new Claim("role", "customer"));
            }


            context.AddRequestedClaims(claims);

            //jwt icinde gormeni saglar
            //context.IssuedClaims = claims;

        }


        public async Task IsActiveAsync(IsActiveContext context)
        {

            var userId = context.Subject.GetSubjectId();

            var user = await _customUserRepository.FindById(int.Parse(userId));

            context.IsActive = user!= null ? true:false;

        }

    }
}
