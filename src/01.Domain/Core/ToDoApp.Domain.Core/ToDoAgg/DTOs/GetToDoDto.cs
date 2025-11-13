using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.CategoryAgg.DTOs;
using ToDoApp.Domain.Core.CategoryAgg.Entities;
using ToDoApp.Domain.Core.ToDoAgg.Enums;
using ToDoApp.Domain.Core.UserAgg.DTOs;
using ToDoApp.Domain.Core.UserAgg.Entities;

namespace ToDoApp.Domain.Core.ToDoAgg.DTOs
{
    public class GetToDoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime DueDate { get; set; }

        public GetCategoryDto Category { get; set; }
        public GetUserSummaryDto? User { get; set; }
    }
}
