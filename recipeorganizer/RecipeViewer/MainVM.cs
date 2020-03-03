using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipesEDM;

namespace RecipeViewer {
    public class MainVM : INotifyPropertyChanged {

        private ObservableCollection<Recipe> _Recipes;
        public ObservableCollection<Recipe> Recipes {
            get {
                if (_Recipes == null)
                    _Recipes = new ObservableCollection<Recipe>();
                return _Recipes;
            }
            set {
                _Recipes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
            }
        }

        private Recipe _SelectedRecipe;
        public Recipe SelectedRecipe {
            get {
                return _SelectedRecipe;
            }
            set {
                _SelectedRecipe = value;
            }
        }

        public MainVM() {
            Recipes = new ObservableCollection<Recipe>();
            FillRecipe();
        }

        public bool AddRecipe(Recipe r, out string msg)
        {
            StringBuilder msgB = new StringBuilder();
            try
            {
                
                using (RecipesContext context = new RecipesContext())
                {
                    context.Recipes.Add(r);
                    foreach (var item in r.Ingredients)
                    {
                        context.Ingredients.Add(item);
                    }
                    context.SaveChanges();
                }
            } catch (DbEntityValidationException dbEx) {
                
                foreach (DbEntityValidationResult entityErr in dbEx.EntityValidationErrors)
                {
                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        msgB.Append(error.PropertyName + ": " + error.ErrorMessage + "\n");
                    }
                }
                msgB.Append("Please, select or fill the required informations.");
                msg = msgB.ToString();
                return false;
            }
            msg = "Saved a Recipe: " + r.Title;
            return true;
        }
        

        public bool DeleteRecipe(int recipeID, out string msg)
        {
            using (RecipesContext context = new RecipesContext())
            {
                try
                {
                    var toDelRecipe = (from r in context.Recipes select r)
                                     .Where(r => r.RecipeID == recipeID).Single();
                    var toDelIngredients = (from ing in context.Ingredients select ing)
                                         .Where(ing => ing.Recipe_RecipeID == recipeID);
                    foreach (var ing in toDelIngredients)
                    {
                        context.Ingredients.Remove(ing);
                    }
                    context.Recipes.Remove(toDelRecipe);
                } catch (InvalidOperationException e)
                {
                    msg = e.Message + ": no Recipe item exists\n" + "Please, use Refresh button!\n";
                    return false;
                } 
                context.SaveChanges();
            }

            FillRecipe();
            msg = "Deleted 1 Recipe item";
            return true;
        }

        public bool UpdateRecipe(Recipe recipe, out string msg)
        {
            using (RecipesContext context = new RecipesContext())
            {
                try
                {
                    var toUpdateRecipe = context.Recipes.Where(r => r.RecipeID == recipe.RecipeID).Single();
                    //var toUpdateRecipe = (from r in context.Recipes select r)
                    //                 .Where(r => r.RecipeID == recipe.RecipeID).Single();
                    toUpdateRecipe.Title = recipe.Title;
                    toUpdateRecipe.RecipeType = recipe.RecipeType;
                    toUpdateRecipe.Yield = recipe.Yield;
                    toUpdateRecipe.ServingSize = recipe.ServingSize;
                    toUpdateRecipe.Comment = recipe.Comment;
                    toUpdateRecipe.Directions = recipe.Directions;

                    var toDelIngredients = (from ing in context.Ingredients select ing)
                                         .Where(ing => ing.Recipe_RecipeID == recipe.RecipeID);
                    
                    foreach (var ing in toDelIngredients)
                    {
                        context.Ingredients.Remove(ing);
                    }
                    foreach(var ing in recipe.Ingredients)
                    {
                        context.Ingredients.Add(new Ingredient { Description = ing.Description, Recipe = toUpdateRecipe });
                    }
                    context.SaveChanges();
                }
                catch (InvalidOperationException e)
                {
                    msg = e.Message + ": no Recipe item exists\n" + "Please, use Refresh button!\n";
                    return false;
                }
                catch (DbEntityValidationException dbEx)
                {
                    StringBuilder msgB = new StringBuilder();
                    foreach (DbEntityValidationResult entityErr in dbEx.EntityValidationErrors)
                    {
                        foreach (DbValidationError error in entityErr.ValidationErrors)
                        {
                            msgB.Append(error.PropertyName + ": " + error.ErrorMessage + "\n");
                        }
                    }
                    msgB.Append("Please, select or fill the required informations.");
                    msg = msgB.ToString();
                    return false;
                }
            }

            FillRecipe();
            msg = "Updated a Recipe: " + recipe.Title;
            return true;
        }

        public void FillRecipe() {
            ObservableCollection<Recipe> res = new ObservableCollection<Recipe>();
            using (RecipesContext context = new RecipesContext()) {
                var q = (from r in context.Recipes
                         select r).Include(r => r.Ingredients).ToList();

                foreach (var r in q) {
                    ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
                    foreach (var ing in r.Ingredients) {
                        ingredients.Add(ing);
                    }
                    switch (r.RecipeType.Trim()) {
                        case "Meal Item":
                            res.Add(new MealItem { RecipeID = r.RecipeID, Title = r.Title, RecipeType = "Meal Item", Yield = r.Yield, ServingSize = r.ServingSize, Directions = r.Directions, Comment = r.Comment, Ingredients = ingredients });
                            break;
                        case "Dessert":
                            res.Add(new Dessert { RecipeID = r.RecipeID, Title = r.Title, RecipeType = "Dessert", Yield = r.Yield, ServingSize = r.ServingSize, Directions = r.Directions, Comment = r.Comment, Ingredients = ingredients });
                            break;
                    }
                }

                Recipes = res;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    public class MealItem : Recipe {
        public override string ToString() {
            return "M-" + base.Title;
        }
    }

    public class Dessert : Recipe {
        public override string ToString() {
            return "D-" + base.Title;
        }
    }

    
}
