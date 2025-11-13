using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core._common.Entities;
using ToDoApp.Domain.Core.ToDoAgg.DTOs;
using ToDoApp.Domain.Core.ToDoAgg.Enums;

namespace ToDoApp.Domain.Core.ToDoAgg.Contracts
{
    public interface IToDoService
    {
        Result<bool> CreateToDo(CreateToDoDto model);
        Result<GetToDoDto> GetToDoById(int id);
        List<GetToDoDto> GetAllToDosByUserId(int userId);
        void MarkAsDone(int toDoId);
        bool? GetStatus(int toDoId);
    }
}
