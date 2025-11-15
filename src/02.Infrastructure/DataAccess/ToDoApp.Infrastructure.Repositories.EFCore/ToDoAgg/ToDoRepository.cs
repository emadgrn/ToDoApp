using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.CategoryAgg.DTOs;
using ToDoApp.Domain.Core.CategoryAgg.Entities;
using ToDoApp.Domain.Core.ToDoAgg.Contracts;
using ToDoApp.Domain.Core.ToDoAgg.DTOs;
using ToDoApp.Domain.Core.ToDoAgg.Entities;
using ToDoApp.Domain.Core.ToDoAgg.Enums;
using ToDoApp.Infrastructure.DB.SqlServer.EFCore.DbContext;

namespace ToDoApp.Infrastructure.Repositories.EFCore.ToDoAgg
{
    public class ToDoRepository: IToDoRepository
    {
        private readonly ApplicationDbContext _context;
        public ToDoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(CreateToDoDto model)
        {
            var entity = new ToDo()
            {
                Title = model.Title,
                Description = model.Description,
                IsDone = false,
                DueDate = model.DueDate,
                CategoryId = model.CategoryId,
                UserId = model.UserId
            };
            _context.Todos.Add(entity);
            _context.SaveChanges();
        }

        public List<GetToDoDto> GetAllToDosByUserId(int userId)
        {
            return _context.Todos
                .Where(td=>td.UserId==userId)
                .Select(td => new GetToDoDto
                {
                    Id = td.Id,
                    Title = td.Title,
                    Description = td.Description,
                    DueDate = td.DueDate,
                    IsDone = td.IsDone,
                    Category = new GetCategoryDto
                    {
                        Id = td.Category.Id,
                        Name = td.Category.Name,
                        ImageUrl = td.Category.ImageUrl!,
                        BriefDescription = td.Category.BriefDescription!
                    }
                })
                .ToList();
        }

        public List<GetToDoDto> GetDynamicToDosOfUser(int userId, string searchTerm, string sortOrder )
        {
            var result = _context.Todos.Where(t => t.UserId == userId)
                .Select(x => new GetToDoDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsDone = x.IsDone,
                    DueDate = x.DueDate,
                    Description = x.Description,
                    Category = new GetCategoryDto
                    {
                        Id = x.Category.Id,
                        Name = x.Category.Name,
                        ImageUrl = x.Category.ImageUrl!,
                        BriefDescription = x.Category.BriefDescription!
                    }
                });

            if (searchTerm is not null)
            {
                result = result.Where(x => x.Title.Contains(searchTerm) || x.Category.Name.Contains(searchTerm));
            }

            switch (sortOrder)
            {
                case "title-asc":
                    result = result.OrderBy(x => x.Title);
                    break;
                case "title-desc":
                    result = result.OrderByDescending(x => x.Title);
                    break;
                case "due-date-asc":
                    result = result.OrderBy(x => x.DueDate);
                    break;
                case "due-date-desc":
                    result = result.OrderByDescending(x => x.DueDate);
                    break;
                case "done":
                    result = result.Where(x => x.IsDone==true);
                    break;
                case "not-done":
                    result = result.Where(x => x.IsDone==false);
                    break;
                case "_":
                default:
                    result = result;
                    break;
            }

            return result.ToList();

        }


        public GetToDoDto? GetById(int toDoId)
        {
            return _context.Todos
                .Where(td => td.Id == toDoId)
                .Select(td => new GetToDoDto()
                {
                    Id = td.Id,
                    Title = td.Title,
                    Description = td.Description,
                    DueDate = td.DueDate,
                    IsDone = td.IsDone,
                    Category = new GetCategoryDto
                    {
                        Id = td.Category.Id,
                        Name = td.Category.Name,
                        ImageUrl = td.Category.ImageUrl!,
                        BriefDescription = td.Category.BriefDescription!
                    }
                }).FirstOrDefault();
        }

        public bool Update(int toDoId, GetToDoDto model)
        {
            var toDo = _context.Todos.FirstOrDefault(td => td.Id == toDoId);

            try
            {
                if (toDo is not null)
                {
                    toDo.DueDate = model.DueDate;
                    toDo.IsDone = model.IsDone;
                    toDo.Title = model.Title;
                    toDo.Description = model.Description;
                    toDo.CategoryId=model.Category.Id;

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

        public bool DeleteById(int toDoId)
        {
            var rowsAffected = _context.Todos
                .Where(x => x.Id == toDoId)
                .ExecuteDelete();

            return rowsAffected > 0;
        }

        public void SetDone(int toDoId)
        {
            var rowAffected=_context.Todos.Where(x => x.Id == toDoId)
                .ExecuteUpdate(setters => setters
                    .SetProperty(x => x.IsDone, true));
        }

        public void SetNotDone(int toDoId)
        {
            var rowAffected = _context.Todos.Where(x => x.Id == toDoId)
                .ExecuteUpdate(setters => setters
                    .SetProperty(x => x.IsDone, false));
        }

        public bool? GetStatusById(int toDoId)
        {
            return _context.Todos
                .Where(td => td.Id == toDoId)
                .Select(td => td.IsDone)
                .FirstOrDefault();
        }
    }
}
