using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Core.CategoryAgg.DTOs
{
    public class GetCategoryDto
    {
        [Display(Name = "شناسه دسته‌بندی")]
        public int Id { get; set; }

        [Display(Name = "عنوان دسته‌بندی")]
        public string Name { get; set; }

        [Display(Name = "توصیف مختصر")]
        public string BriefDescription { get; set; }

        [Display(Name = "آدرس تصویر")]
        public string ImageUrl { get; set; }
    }
}
