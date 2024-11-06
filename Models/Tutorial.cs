using System.ComponentModel.DataAnnotations;

namespace TutorialEx.Models
{
    public class Tutorial
    {
        [Key]
        
        public  int?  Id { get; set; }
        [Required]
        public string? TutorialName { get; set; }

        [StringLength(100)]
        [Required]
        public string? TutorialDescription { get; set; }
        public List<Article>? Articles { get; set; }
    }
}
