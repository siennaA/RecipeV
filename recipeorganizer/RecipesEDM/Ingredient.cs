using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesEDM {
    [Table("Ingredient")]
    public partial class Ingredient {       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IngredientID { get; set; }

        [Required, MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public int Recipe_RecipeID { get; set; }

        [ForeignKey("Recipe_RecipeID")]
        public Recipe Recipe { get; set; }
    }
}
