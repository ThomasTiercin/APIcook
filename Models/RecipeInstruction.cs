using System.ComponentModel.DataAnnotations.Schema;

namespace APIcook.Models
{
    public class RecipeInstruction
    {
        public int Id { get; set; }
        
        public string Value { get; set; }

        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
    }
}
