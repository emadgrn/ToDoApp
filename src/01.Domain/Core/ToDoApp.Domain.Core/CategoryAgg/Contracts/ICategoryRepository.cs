using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.CategoryAgg.DTOs;

namespace ToDoApp.Domain.Core.CategoryAgg.Contracts
{
    public interface ICategoryRepository
    {
        List<GetCategoryDto> GetAll();
        List<String> GetAllCategoriesNames();
        public void Create(CreateCategoryDto model);
        public GetCategoryDto? GetById(int id);
        public bool Update(int categoryId, GetCategoryDto model);
        public bool DeleteById(int categoryId);
    }
}
