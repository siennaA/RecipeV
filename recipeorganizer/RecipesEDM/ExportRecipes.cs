using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;
using System.Data.Entity;
using RecipeDataAccess;

namespace RecipesEDM {
    public class ExportRecipes {
        public static void ExportRecipesToXml(RecipesContext context) {
            XDocument doc = GetXDocumentFromRecipeTable(context);
            doc.Save(XmlHandler.XmlBackupDirectory + "Recipes.Xml");

            doc = GetXDocumentFromIngredientTable(context);
            doc.Save(XmlHandler.XmlBackupDirectory + "Ingredients.Xml");
            MessageBox.Show("[Recipe], [Ingredient] Table exported to \"Recipes.Xml\" and \"Ingredients.Xml\"", "Notice");
        }


        static XDocument GetXDocumentFromRecipeTable(RecipesContext context) {
            var recipes = context.Recipes.Select(s => s).ToList();

            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Contents of [Recipe] Table in [Recipes] DB"),
                new XElement("Recipes", recipes.Select(r => new XElement("Recipe", new XElement("RecipeID", r.RecipeID),
                                                                new XElement("Title", r.Title),
                                                                new XElement("RecipeType", r.RecipeType),
                                                                string.IsNullOrEmpty(r.ServingSize)? null : new XElement("ServingSize", r.ServingSize),
                                                                new XElement("Yield", r.Yield),
                                                                new XElement("Directions", r.Directions),
                                                                string.IsNullOrEmpty(r.Comment)? null : new XElement("Comment", r.Comment)))));

        }

        static XDocument GetXDocumentFromIngredientTable(RecipesContext context) {
            var ingredients = context.Ingredients.Select(ing => ing).ToList();

            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Contents of [Ingredient] Table in [Recipes] DB"),
                new XElement("Ingredients", ingredients.Select(ing => new XElement("Ingredient", new XElement("IngredientID", ing.IngredientID),
                                                                        new XElement("RecipeID", ing.Recipe_RecipeID),
                                                                        new XElement("Description", ing.Description)))));

        }
    }
}
