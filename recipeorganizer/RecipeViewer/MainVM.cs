using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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

        public MainVM() {
            Recipes = new ObservableCollection<Recipe>();
            Recipes = FillRecipe();
        }

        public ObservableCollection<Recipe> FillRecipe() {
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
                return res;
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
