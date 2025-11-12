using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp.Domain.Core.ToDoAgg.Entities;
using ToDoApp.Domain.Core.ToDoAgg.Enums;

namespace ToDoApp.Infrastructure.DB.SqlServer.EFCore.Configurations
{
    public class ToDoConfiguration:IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);

            builder.Property(c => c.Description).IsRequired(false);

            builder.Property(u => u.Status).IsRequired()
                .HasConversion<string>()
                .HasDefaultValue(StatusEnum.Pending);

            builder.HasOne(t => t.User)
                .WithMany(u => u.ToDos)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
