using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Core.CategoryAgg.Contracts;
using ToDoApp.Domain.Core.CategoryAgg.DTOs;
using ToDoApp.Domain.Core.CategoryAgg.Entities;
using ToDoApp.Infrastructure.DB.SqlServer.EFCore.DbContext;

namespace ToDoApp.Infrastructure.Repositories.EFCore.CategoryAgg
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(CreateCategoryDto model)
        {
            var entity = new Category()
            {
                Name = model.Name,
                BriefDescription = model.BriefDescription,
                ImageUrl = model.ImageUrl,
            };
            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public List<GetCategoryDto> GetAll()
        {
            return _context.Categories
                .Select(c => new GetCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    BriefDescription = c.BriefDescription,
                    ImageUrl = c.ImageUrl
                }).ToList();
        }

        public GetCategoryDto? GetById(int id)
        {
            return _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new GetCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    BriefDescription = c.BriefDescription,
                    ImageUrl = c.ImageUrl
                }).FirstOrDefault();
        }

        public List<string> GetAllCategoriesNames()
        {
            return _context.Categories
                .Select(c => c.Name)
                .ToList();
        }



        public bool Update(int categoryId, GetCategoryDto model)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);

            try
            {
                if (category is not null)
                {
                    category.Name = model.Name;
                    category.BriefDescription = model.BriefDescription;
                    
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

        public bool DeleteById(int categoryId)
        {
            var rowsAffected = _context.Categories
                .Where(x => x.Id == categoryId)
                .ExecuteDelete();

            return rowsAffected > 0;
        }





    }
}
