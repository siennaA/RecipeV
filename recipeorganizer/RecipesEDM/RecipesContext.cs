using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesEDM {
    public partial class RecipesContext : DbContext
    {
        public RecipesContext() : base("name=RecipesEDM") { }        
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override System.Data.Entity.Validation.DbEntityValidationResult 
            ValidateEntity(DbEntityEntry entityEntry, System.Collections.Generic.IDictionary<object, object> items)
        {
            var list = new List<System.Data.Entity.Validation.DbValidationError>();

            if (entityEntry.Entity is Recipe)
            {
                if (entityEntry.CurrentValues.GetValue<string>("Title") == "")                
                    list.Add(new System.Data.Entity.Validation.DbValidationError("Title", "Recipe Title is required"));                
                if (entityEntry.CurrentValues.GetValue<string>("RecipeType") == "")
                    list.Add(new System.Data.Entity.Validation.DbValidationError("Title", "Recipe RecipeType is required"));
                if (entityEntry.CurrentValues.GetValue<string>("Yield") == "")                
                    list.Add(new System.Data.Entity.Validation.DbValidationError("Yield", "Recipe Yield is required"));
                if (entityEntry.CurrentValues.GetValue<string>("Directions") == "")
                    list.Add(new System.Data.Entity.Validation.DbValidationError("Directions", "Recipe Directions is required"));
                return new System.Data.Entity.Validation.DbEntityValidationResult(entityEntry, list);
            }
            else if (entityEntry.Entity is Ingredient)
            {
                if (entityEntry.CurrentValues.GetValue<string>("Description") == "")
                    list.Add(new System.Data.Entity.Validation.DbValidationError("Description", "Ingredient Description is required"));
                return new System.Data.Entity.Validation.DbEntityValidationResult(entityEntry, list);
            }
            return base.ValidateEntity(entityEntry, items);
        }
    }
}
