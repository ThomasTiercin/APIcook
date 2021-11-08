using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
