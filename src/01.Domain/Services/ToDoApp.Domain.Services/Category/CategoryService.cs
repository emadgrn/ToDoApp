using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.CategoryAgg.Contracts;
using ToDoApp.Domain.Core.CategoryAgg.DTOs;

namespace ToDoApp.Domain.Services.Category
{
    public class CategoryService(ICategoryRepository categoryRepo): ICategoryService
    {
        public List<GetCategoryDto> GetCategories()
        {
            return categoryRepo.GetAll();
        }
    }
}
