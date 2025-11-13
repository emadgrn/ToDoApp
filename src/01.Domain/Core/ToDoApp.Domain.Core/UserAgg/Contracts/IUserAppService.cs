using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core._common.Entities;
using ToDoApp.Domain.Core.UserAgg.DTOs;

namespace ToDoApp.Domain.Core.UserAgg.Contracts
{
    public interface IUserAppService
    {
        Result<GetUserSummaryDto> Login(string username, string password);
        Result<GetUserSummaryDto> Register(CreateUserDto model);
        Result<GetUserDto> GetUserById(int id);
        UpdateUserDto? GetUpdateUserDetails(int userId);
        Result<bool> Update(int userId, UpdateUserDto model);
        bool DeleteUser(int userId);
    }
}
