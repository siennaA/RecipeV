using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RecipesEDM;
using System.Xml.Linq;
using System.Xml;
using RecipeDataAccess;


namespace RecipesUnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Test()
        {

            List<Recipe> rList = RecipesDBInitializer.GetRecipesFromXDocument(XDocument.Load(XmlHandler.XmlBackupDirectory + "Recipes.xml"));
            List<Ingredient> iList = RecipesDBInitializer.GetIngredientsFromXDocument(XDocument.Load(XmlHandler.XmlBackupDirectory + "Ingredients.xml"));

            var db = new RecipesContext();
            int recipes = (from r in db.Recipes
                           select r).ToList().Count;

            int ing = (from i in db.Ingredients
                       select i).ToList().Count;

            Assert.AreEqual(rList.Count, recipes, 0, $"Recipe XML count: {rList.Count}, Recipe DB count: {recipes}");
            Assert.AreEqual(iList.Count, ing, 0, $"Ingredient XML count: {iList.Count}, Ingredient DB count: {ing}");


        }

    }
}
