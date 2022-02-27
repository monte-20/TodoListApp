using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Shared
{
    public class TodoItem
    {
        [Required]
        public string? Title { get; set; }
        public string Description { get; set; } = String.Empty;
        public int Estimate { get; set; } = 0;

        public int Id{ get; set; }

        public bool Done { get; set; } = false;
    }
}
