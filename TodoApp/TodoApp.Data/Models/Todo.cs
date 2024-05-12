using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Data.Models
{
    [Table("Todo")]
    public class Todo
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
