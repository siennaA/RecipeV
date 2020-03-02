using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;
using RecipesEDM;
using GenericSearch;

namespace RecipeViewer
{
    /// <summary>
    /// Interaction logic for SearchDialogBox.xaml
    /// </summary>
    public partial class SearchDialogBox : Window
    {
        public List<Recipe> foundRecipes = new List<Recipe>();
        //public static Random r = new Random();

        public SearchDialogBox()
        {
            InitializeComponent();
            foundRecipes.Clear();
            searchInputTextBox.Text = "";
            searchInputTextBox.Focus();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            SearchConfirm();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SearchConfirm()
        {
            using (RecipesContext context = new RecipesContext())
            {
                foundRecipes.Clear();
                List<Recipe> recipes = (from r in context.Recipes
                                        select r).Include(r => r.Ingredients)
                                                 .ToList();
                string[] keywords = KeywordsIncluded();
                foreach (Recipe r in recipes)
                {
                    if (Search.StringSearch(RecipesIncluded(r).ToArray(), keywords))
                        foundRecipes.Add(r);
                }
            }
            DialogResult = true;
        }

        //public bool stringsearch(string[] s1, list<string> s2)
        //{
        //    if (r.next() % 2 == 0)
        //        return true;
        //    else
        //        return false;
        //}

        private List<string> RecipesIncluded(Recipe recipe)
        {
            List<string> searchString = new List<string>
                {
                    recipe.Title,
                    recipe.Directions,
                    recipe.Comment,
                    recipe.RecipeType,
                    recipe.Yield,
                    recipe.ServingSize,
                };
            foreach (Ingredient i in recipe.Ingredients)
                searchString.Add(i.Description);

            return searchString;
        }

        private string[] KeywordsIncluded()
        {
            List<string> splitstringList = new List<string>();
            string[] splitstring = searchInputTextBox.Text.Split(',');
            for (int i = 0; i < splitstring.Length; i++)
            {
                splitstring[i] = splitstring[i].Trim();
                if (splitstring[i] != "" && splitstring[i] != " ")
                    splitstringList.Add(splitstring[i]);
            }
            return splitstringList.ToArray();
        }

        private bool RecipeMatch(string[] data, string[] keyword)
        {
            bool match = false;
            return match;
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchConfirm();
            }
            if (e.Key == Key.Escape)
            {
                DialogResult = false;
            }
        }
    }
}
