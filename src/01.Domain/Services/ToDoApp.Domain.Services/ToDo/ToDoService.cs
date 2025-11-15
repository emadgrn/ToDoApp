using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core._common.Entities;
using ToDoApp.Domain.Core.ToDoAgg.Contracts;
using ToDoApp.Domain.Core.ToDoAgg.DTOs;
using ToDoApp.Domain.Core.ToDoAgg.Enums;
using ToDoApp.Domain.Core.UserAgg.DTOs;
using ToDoApp.Infrastructure.Repositories.EFCore.ToDoAgg;

namespace ToDoApp.Domain.Services.ToDo
{
    public class ToDoService(IToDoRepository toDoRepo) : IToDoService
    {
        public Result<bool> CreateToDo(CreateToDoDto model)
        {
            try
            {
                toDoRepo.Create(model);
                return Result<bool>.Success("کار با موفقیت ذخیره شد.");
            }
            catch
            {
                return Result<bool>.Failure("ایجاد کار با خطا روبرو شد.");
            }
        }

        public Result<GetToDoDto> GetToDoById(int id)
        {
            var toDoDto = toDoRepo.GetById(id);

            if (toDoDto is not null)
            {
                return Result<GetToDoDto>.Success("", toDoDto);
            }
            else
            {
                return Result<GetToDoDto>.Failure($"کار با این آیدی {id} وجود ندارد");
            }
        }


        public List<GetToDoDto> GetUserToDos(int userId, string searchTerm,string sortOrder )
        {
            return toDoRepo.GetDynamicToDosOfUser(userId, searchTerm, sortOrder);
        }

        public bool? GetStatus(int toDoId)
        {
            return toDoRepo.GetStatusById(toDoId);
        }

        public void MarkAsDone(int toDoId)
        {
            toDoRepo.SetDone(toDoId);
        }

        public void MarkAsNotDone(int toDoId)
        {
            toDoRepo.SetNotDone(toDoId);
        }

        public void Delete(int toDoId)
        { 
            toDoRepo.DeleteById(toDoId);
        }
    }
}
