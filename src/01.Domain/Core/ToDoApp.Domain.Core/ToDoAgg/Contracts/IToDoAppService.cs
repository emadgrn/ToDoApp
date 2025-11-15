using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core._common.Entities;
using ToDoApp.Domain.Core.ToDoAgg.DTOs;

namespace ToDoApp.Domain.Core.ToDoAgg.Contracts
{
    public interface IToDoAppService
    {
        Result<bool> CreateToDo(CreateToDoDto model);

        Result<List<GetToDoDto>> GetUserTasks(int userId, string searchTerm, string sortOrder);
        void DeleteToDo(int toDoId);
        void MarkAsDone(int toDoId);
        void MarkAsNotDone(int toDoId);
    }
}
