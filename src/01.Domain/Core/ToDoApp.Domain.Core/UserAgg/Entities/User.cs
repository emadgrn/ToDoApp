using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Core.ToDoAgg.Entities;

namespace ToDoApp.Domain.Core.UserAgg.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ToDo> ToDos { get; set; } = [];

    }
}
