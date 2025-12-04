using System.ComponentModel.DataAnnotations;

namespace reminderswebapi1.Models
{
    public class ToDo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
    }
}
