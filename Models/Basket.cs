using System.ComponentModel.DataAnnotations.Schema;

namespace APIcook.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
