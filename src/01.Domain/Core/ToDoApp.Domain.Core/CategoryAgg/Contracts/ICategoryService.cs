using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.CategoryAgg.DTOs;

namespace ToDoApp.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryService
    { 
        List<GetCategoryDto> GetCategories();
    }
}
