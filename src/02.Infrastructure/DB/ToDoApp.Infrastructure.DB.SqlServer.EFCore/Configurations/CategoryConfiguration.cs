using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.CategoryAgg.Entities;

namespace ToDoApp.Infrastructure.DB.SqlServer.EFCore.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.Property(c => c.BriefDescription).IsRequired(false);

            builder.HasData(
                new Category { Id = 1, Name = "شخصی", ImageUrl = "Files\\Category\\personal.png" },
                new Category { Id = 2, Name = "کاری", ImageUrl = "Files\\Category\\work.png" },
                new Category { Id = 3, Name = "دانشگاهی", ImageUrl = "Files\\Category\\edu.png" },
                new Category { Id = 4, Name = "سایر", ImageUrl = "Files\\Category\\other.png" }
            );
        }
    }
}
