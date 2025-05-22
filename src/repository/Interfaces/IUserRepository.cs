using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Dtos;
using app.src.model;
using Microsoft.Build.Framework;

namespace app.src.repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> getUserById(long id);
        Task<User> saveUser(SaveUserRequest request);
        Task<User?> getUserByName(string name);
    }
}