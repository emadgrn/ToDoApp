using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core._common.Entities;
using ToDoApp.Domain.Core.ToDoAgg.Contracts;
using ToDoApp.Domain.Core.ToDoAgg.DTOs;

namespace ToDoApp.Domain.ApplicationServices.ToDo
{
    public class ToDoAppService(IToDoService toDoService) : IToDoAppService
    {

        public Result<bool> CreateToDo(CreateToDoDto model)
        {
            return toDoService.CreateToDo(model);
        }

        public Result<List<GetToDoDto>> GetUserTasks(int userId, string searchTerm, string sortOrder)
        {
            var result = toDoService.GetUserToDos(userId, searchTerm, sortOrder);

            if (result.Any())
            {
                return Result<List<GetToDoDto>>.Success("", result);
            }
            else
            {
                return Result<List<GetToDoDto>>.Failure("هیچ کاری برای شما ثبت نشده است.");
            }
        }

        public void MarkAsDone(int toDoId)
        {
            toDoService.MarkAsDone(toDoId);
        }

        public void MarkAsNotDone(int toDoId)
        {
            toDoService.MarkAsNotDone(toDoId);
        }

        public void DeleteToDo(int toDoId)
        {
            toDoService.Delete(toDoId);
        }
    }
}
