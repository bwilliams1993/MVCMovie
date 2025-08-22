using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$"), Required, StringLength(30)]
        public string Descripton { get; set; }
    }
}