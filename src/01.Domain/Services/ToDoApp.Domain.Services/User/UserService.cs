using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core._common.Entities;
using ToDoApp.Domain.Core.UserAgg.Contracts;
using ToDoApp.Domain.Core.UserAgg.DTOs;

namespace ToDoApp.Domain.Services.User
{
    public class UserService(IUserRepository userRepo) : IUserService
    {


        public Result<GetUserSummaryDto> Login(string username, string password)
        {
            var loginData = userRepo.Login(username, password);

            if (loginData is not null)
            {
                return Result<GetUserSummaryDto>.Success("لاگین با موفقیت انجام شد.", loginData);

            }
            else
            {
                return Result<GetUserSummaryDto>.Failure("نام کاربری یا کلمه عبور اشتباه می باشد.");
            }
        }

        public Result<GetUserSummaryDto> Register(CreateUserDto model)
        {
            var usernameExist = userRepo.UsernameExists(model.Username);

            if (usernameExist)
            {
                return Result<GetUserSummaryDto>.Failure("کاربر با این نام کاربری موجود می باشد.");
            }

            var registerData = userRepo.Register(model);

            if (registerData is not null)
            {
                return Result<GetUserSummaryDto>.Success("ثبت نام با موفقیت انجام شد.", registerData);

            }
            else
            {
                return Result<GetUserSummaryDto>.Failure("ثبت نام با مشکل مواجه شد.");
            }
        }

        public Result<GetUserDto> GetUserById(int id)
        {
            var userDto = userRepo.GetById(id);

            if (userDto is not null)
            {
                return Result<GetUserDto>.Success("", userDto);
            }
            else
            {
                return Result<GetUserDto>.Failure($"کاربر با این آیدی {id} وجود ندارد");
            }
        }

        public UpdateUserDto? GetUpdateUserDetails(int userId)
        {
            return userRepo.GetUpdateUserDetailsById(userId);
        }

        public Result<bool> Update(int userId, UpdateUserDto model)
        {
            var result = userRepo.Update(userId, model);

            if (result)
            {
                return Result<bool>.Success("اطلاعات کاربر با موفقیت به‌روزرسانی شد.");
            }
            else
            {
                return Result<bool>.Failure("به‌روزرسانی اطلاعات کاربر با خطا مواجه شد.");
            }
        }

        public bool DeleteUser(int userId)
        {
            return userRepo.DeleteById(userId);
        }
    }
}
