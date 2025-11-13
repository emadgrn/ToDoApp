using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Core.UserAgg.DTOs
{
    public class GetUserSummaryDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
    }
}
