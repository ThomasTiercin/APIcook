﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIcook.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        
        public long Amount { get; set; }

        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public int MeasureId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
        [ForeignKey("IngredientId")]
        public virtual Ingredient Ingredient { get; set; }
        [ForeignKey("MeasureId")]
        public virtual Measure Measure { get; set; }
    }
}
