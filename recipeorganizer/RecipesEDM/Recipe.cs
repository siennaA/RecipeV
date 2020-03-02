using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesEDM
    {
    [Table("Recipe")]
    public partial class Recipe
    {        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RecipeID { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Yield { get; set; }

        public string ServingSize { get; set; }

        [Required]
        public string Directions { get; set; }


        public string Comment { get; set; }

        [Required, MaxLength(30)]
        public string RecipeType { get; set; }

        [InverseProperty("Recipe")]
        public virtual ICollection<Ingredient> Ingredients { get; set; }

    }

   
    
}

