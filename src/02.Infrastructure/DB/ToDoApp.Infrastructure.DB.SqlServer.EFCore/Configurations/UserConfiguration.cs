using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.UserAgg.Entities;

namespace ToDoApp.Infrastructure.DB.SqlServer.EFCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.Username).IsUnique();

            builder.Property(u => u.Password).IsRequired().HasMaxLength(100);

            builder.Property(u => u.Firstname).IsRequired().HasMaxLength(50);

            builder.Property(u => u.Lastname).IsRequired().HasMaxLength(50);


            builder.Property(u => u.PhoneNumber).HasMaxLength(12);
            builder.Property(u => u.PhoneNumber).IsRequired(false);


            builder.Property(u => u.CreatedAt).IsRequired();


            builder.HasData(
                new User { Id = 1, Firstname = "عماد", Lastname = "گرامی", Username = "emad", Password = "emad", CreatedAt = new DateTime(2024, 07, 3, 0, 0, 0) },
                new User { Id = 2, Firstname = "علی", Lastname = "علیپور", Username = "ali", Password = "ali", CreatedAt = new DateTime(2024, 08, 14, 0, 0, 0) }
            );
        }
    }
}
