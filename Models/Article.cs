using System.ComponentModel.DataAnnotations;

namespace TutorialEx.Models
{
    public class Article
    {
        [Key]
        public  int  ArtcleId { get; set; }
        [Required(ErrorMessage ="Please Enter ArticleTitle")]
        public string ArticleTitle { get; set; }
        [Required(ErrorMessage = "Please Enter ArticleContent")]
        public string ArticleContent { get; set; }
        public int TutorialId {  get; set; }
        public Tutorial Tutorial { get; set; }
    }
}
