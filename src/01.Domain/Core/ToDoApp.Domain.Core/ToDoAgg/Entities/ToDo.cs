using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.CategoryAgg.Entities;
using ToDoApp.Domain.Core.ToDoAgg.Enums;
using ToDoApp.Domain.Core.UserAgg.Entities;

namespace ToDoApp.Domain.Core.ToDoAgg.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; } 
        public DateTime DueDate { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

    }
}
