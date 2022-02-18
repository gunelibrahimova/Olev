using System.ComponentModel.DataAnnotations;

namespace K205Oleev.Models
{
    public class About : Base
    {
        [Required]
        [StringLength(100, MinimumLength =6, ErrorMessage ="Minimum 6 olmalidir ")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoURL { get; set; }
    }
}
