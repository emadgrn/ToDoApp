using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.ToDoAgg.DTOs;
using ToDoApp.Domain.Core.ToDoAgg.Enums;

namespace ToDoApp.Domain.Core.ToDoAgg.Contracts
{
    public interface IToDoRepository
    {
        void Create(CreateToDoDto model);
        List<GetToDoDto> GetAllToDosByUserId(int userId);
        List<GetToDoDto> GetDynamicToDosOfUser(int userId, string searchTerm, string sortOrder);
        GetToDoDto? GetById(int toDoId);
        bool? GetStatusById(int toDoId);
        bool Update(int toDoId, GetToDoDto model);
        bool DeleteById(int toDoId);
        void SetDone(int toDoId);
        void SetNotDone(int toDoId);

    }
}
