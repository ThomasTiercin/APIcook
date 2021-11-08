using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIcook.Models
{
    public class BasketRecipeIngredient
    {
        public int Id { get; set; }

        public Boolean Visible { get; set; }
        public int BasketId { get; set; }
        public int RecipeIngredientId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("BasketId")]
        public virtual Basket Basket { get; set; }
        [ForeignKey("RecipeIngredientId")]
        public virtual RecipeIngredient RecipeIngredient { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
