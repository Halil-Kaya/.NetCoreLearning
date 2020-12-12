using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyIdentityServer.AuthServer.Models;

namespace UdemyIdentityServer.AuthServer.Repository
{
    public class CustomUserRepository : ICustomUserRepository
    {

        private readonly CustomDbContext _context;

        public CustomUserRepository(CustomDbContext context)
        {
            this._context = context;
        }


        public async Task<CustomUser> FindByEmail(string email)
        {
            return await _context.customUsers.FirstOrDefaultAsync(x => x.Emai == email);
        }


        public async Task<CustomUser> FindById(int id)
        {
            return await _context.customUsers.FindAsync(id);
        }

        public async Task<bool> Validate(string email, string password)
        {
            return await _context.customUsers.AnyAsync(x => x.Emai == email &&  x.Password == password);
        }

    }
}
