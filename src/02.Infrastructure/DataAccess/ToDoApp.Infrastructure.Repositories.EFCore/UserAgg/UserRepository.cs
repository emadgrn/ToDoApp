using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Core.UserAgg.Contracts;
using ToDoApp.Domain.Core.UserAgg.DTOs;
using ToDoApp.Domain.Core.UserAgg.Entities;
using ToDoApp.Infrastructure.DB.SqlServer.EFCore.DbContext;

namespace ToDoApp.Infrastructure.Repositories.EFCore.UserAgg
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<GetUserDto> GetAll()
        {
            return _context.Users
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    PhoneNumber = u.PhoneNumber,
                    CreatedAt = u.CreatedAt
                })
                .ToList();
        }


        public GetUserDto? GetById(int id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Select(u => new GetUserDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    PhoneNumber = u.PhoneNumber,
                    CreatedAt = u.CreatedAt
                })
                .FirstOrDefault();
        }


        public GetUserSummaryDto? Login(string username, string password)
        {
            return _context.Users
                .Where(u => u.Username == username && u.Password == password)
                .Select(u => new GetUserSummaryDto()
                {
                    Id = u.Id,
                    Username = u.Username,
                    Fullname = u.Firstname + " " + u.Lastname,
                })
                .FirstOrDefault();
        }
        public bool UsernameExists(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }

        public GetUserSummaryDto? Register(CreateUserDto model)
        {
            var entity = new User
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Username = model.Username,
                Password = model.Password,
                CreatedAt = DateTime.Now,
                PhoneNumber = model.PhoneNumber
            };
            _context.Users.Add(entity);
            _context.SaveChanges();

            return new GetUserSummaryDto()
            {
                Id = entity.Id,
                Username = entity.Username,
                Fullname = entity.Firstname + " " + entity.Lastname,
            };
        }

        public UpdateUserDto? GetUpdateUserDetailsById(int id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UpdateUserDto()
                {
                    Id = u.Id,
                    Username = u.Username,
                    Firstname = u.Firstname,
                    Lastname = u.Lastname,
                    PhoneNumber = u.PhoneNumber,
                    Password = u.Password
                })
                .FirstOrDefault();
        }

        public bool Update(int userId, UpdateUserDto model)
        {

            var user = _context.Users
                .FirstOrDefault(u => u.Id == userId);

            try
            {
                if (user is not null)
                {
                    user.Username = model.Username;
                    user.Password = model.Password;
                    user.Firstname = model.Firstname;
                    user.Lastname = model.Lastname;
                    user.PhoneNumber = model.PhoneNumber;

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteById(int userId)
        {
            var rowsAffected = _context.Users
                .Where(x => x.Id == userId)
                .ExecuteDelete();

            return rowsAffected > 0;
        }
    }
}
