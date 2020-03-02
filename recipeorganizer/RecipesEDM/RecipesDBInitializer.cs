using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows;
using System.Data.Entity;
using RecipeDataAccess;

namespace RecipesEDM
{
    public class RecipesDBInitializer : CreateDatabaseIfNotExists<RecipesContext>
    {

        protected override void Seed(RecipesContext context)
        {
            try
            {
                List<Recipe> recipes = GetRecipesFromXDocument(XDocument.Load(XmlHandler.XmlBackupDirectory + "Recipes.Xml"));
                foreach (var r in recipes)
                {
                    context.Recipes.Add(r);
                }

                List<Ingredient> ingredients = GetIngredientsFromXDocument(XDocument.Load(XmlHandler.XmlBackupDirectory + "Ingredients.Xml"));
                foreach (var ing in ingredients)
                {
                    context.Ingredients.Add(ing);
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static List<Recipe> GetRecipesFromXDocument(XDocument doc)
        {
            List<XElement> recipesXml = doc.Descendants("Recipe").ToList();
            List<Recipe> recipes = new List<Recipe>(recipesXml.Count);
            foreach (XElement e in recipesXml)
            {
                var recipeID = Int32.Parse(e.Element("RecipeID").Value);
                var title = e.Element("Title").Value;
                title = title.Length <= 50 ? title : title.Substring(0, 50);
                var recipeType = e.Element("RecipeType").Value;
                var servingSize = e.Element("ServingSize")?.Value;
                var yield = e.Element("Yield").Value;
                var directions = e.Element("Directions").Value;
                var comment = e.Element("Comment")?.Value;
                recipes.Add(new Recipe { RecipeID = recipeID, Title = title, RecipeType = recipeType, ServingSize = servingSize, Yield = yield, Directions = directions, Comment = comment });
            }
            return recipes;
        }

        public static List<Ingredient> GetIngredientsFromXDocument(XDocument doc)
        {
            List<XElement> ingredientsXml = doc.Descendants("Ingredient").ToList();
            List<Ingredient> ingredients = new List<Ingredient>(ingredientsXml.Count);
            foreach (var e in ingredientsXml)
            {
                var ingredientID = Int32.Parse(e.Element("IngredientID").Value);
                var recipe_RecipeID = Int32.Parse(e.Element("RecipeID").Value);
                var description = e.Element("Description").Value;
                ingredients.Add(new Ingredient { IngredientID = ingredientID, Recipe_RecipeID = recipe_RecipeID, Description = description });
            }
            return ingredients;
        }
    }
}
