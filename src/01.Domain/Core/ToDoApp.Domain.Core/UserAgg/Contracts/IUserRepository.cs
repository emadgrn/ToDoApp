using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.UserAgg.DTOs;

namespace ToDoApp.Domain.Core.UserAgg.Contracts
{
    public interface IUserRepository
    {
        List<GetUserDto> GetAll();
        GetUserDto? GetById(int id);
        GetUserSummaryDto? Login(string username, string password);
        GetUserSummaryDto? Register(CreateUserDto model);
        bool UsernameExists(string username);
        public bool Update(int userId, UpdateUserDto model);
        public UpdateUserDto? GetUpdateUserDetailsById(int id);
        public bool DeleteById(int userId);
    }
}
