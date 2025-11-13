using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core._common.Entities;
using ToDoApp.Domain.Core.UserAgg.Contracts;
using ToDoApp.Domain.Core.UserAgg.DTOs;

namespace ToDoApp.Domain.ApplicationServices.User
{
    public class UserAppService(IUserService userService):IUserAppService
    {
        public Result<GetUserSummaryDto> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return Result<GetUserSummaryDto>.Failure("نام کاربری یا رمز عبور خالی است.");

            return userService.Login(username, password);
        }

        public Result<GetUserSummaryDto> Register(CreateUserDto model)
        {
            if (string.IsNullOrWhiteSpace(model.Username))
                return Result<GetUserSummaryDto>.Failure("نام کاربری الزامی است.");

            return userService.Register(model);
        }

        public Result<GetUserDto> GetUserById(int id)
        {
            return userService.GetUserById(id);
        }

        public UpdateUserDto? GetUpdateUserDetails(int userId)
        {
            return userService.GetUpdateUserDetails(userId);
        }

        public Result<bool> Update(int userId, UpdateUserDto model)
        {
            return userService.Update(userId, model);
        }

        public bool DeleteUser(int userId)
        {
            return userService.DeleteUser(userId);
        }
    }
}
