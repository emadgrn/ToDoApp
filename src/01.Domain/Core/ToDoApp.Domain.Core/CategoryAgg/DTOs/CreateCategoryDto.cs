using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Core.CategoryAgg.DTOs
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string? BriefDescription { get; set; }
        public string? ImageUrl { get; set; }
    }
}
