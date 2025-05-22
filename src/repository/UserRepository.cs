using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.data;
using app.src.Dtos;
using app.src.model;
using app.src.repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace app.src.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User?> getUserById(long id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return null;

            return user;
        }

        public async Task<User?> getUserByName(string name)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == name.ToLower());
            if (res == null) return null;
            
            return res;
        }

        public async Task<User> saveUser(SaveUserRequest request)
        {
            User user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}