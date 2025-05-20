using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.src.Dtos;
using app.src.model;

namespace app.src.repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> getUserById(long id);
        Task<User> saveUser(SaveUserRequest request);
    }
}