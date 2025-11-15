using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.ApplicationServices.ToDo;
using ToDoApp.Domain.ApplicationServices.User;
using ToDoApp.Domain.Core.CategoryAgg.Contracts;
using ToDoApp.Domain.Core.ToDoAgg.Contracts;
using ToDoApp.Domain.Core.UserAgg.Contracts;
using ToDoApp.Domain.Services.Category;
using ToDoApp.Domain.Services.ToDo;
using ToDoApp.Domain.Services.User;
using ToDoApp.Infrastructure.DB.SqlServer.EFCore.DbContext;
using ToDoApp.Infrastructure.Repositories.EFCore.CategoryAgg;
using ToDoApp.Infrastructure.Repositories.EFCore.ToDoAgg;
using ToDoApp.Infrastructure.Repositories.EFCore.UserAgg;

namespace ToDoApp.Presentation.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserAppService,UserAppService>();


            builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
            builder.Services.AddScoped<IToDoService, ToDoService>();
            builder.Services.AddScoped<IToDoAppService, ToDoAppService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
