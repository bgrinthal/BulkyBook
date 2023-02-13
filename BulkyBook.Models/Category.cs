using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        // Data Annotation that changes the name of DisplayOrder that displays
        [DisplayName("Display Order")]
        // Only allows numbers 1 - 100, with custom error message
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
