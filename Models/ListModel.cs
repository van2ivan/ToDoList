using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ListModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Task name must have at least 3 characters")]
        public string Name { get; set; }
        [StringLength(100)]
        public string? Description { get; set; }
    }
}
