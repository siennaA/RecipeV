using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using RecipesEDM;

namespace RecipeViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string ErrorBoxMessage;
        public static Exception TopErrorException;

        private bool validWindowClose = false;
        public MainVM Vm = new MainVM();

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                
                DataContext = Vm;
                SortTypeName();
                

            }
            catch (NullReferenceException ex)
            {
                SetTopExceptionError(ex, "The database failed to load correctly.");
            }
            catch (AggregateException ex)
            {
                foreach (Exception inner in ex.Flatten().InnerExceptions)
                {
                    if (inner.InnerException != null)
                    {
                        Startup.GoldenNuggetException(inner.InnerException);
                    }
                }
            }
            catch (Exception ex)
            {
                SetTopExceptionError(ex, ex.Message);
            }

            if (ErrorBoxMessage != null)
            {
                SetMessageBox(ErrorBoxMessage);
            }
            else
            {
                SetMessageBox("The database has been loaded correctly.", true);
            }
        }

        public void SortTypeName() {
            CollectionViewSource CoView = (CollectionViewSource)(this.Resources["CoView"]);
            PropertyGroupDescription pgd = new PropertyGroupDescription();
            pgd.PropertyName = "RecipeType";
            CoView.GroupDescriptions.Add(pgd);

            CoView.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
        }
        public void SetMessageBox(string message, bool positive = false)
        {
            if (!positive)
                textBlockNotifications.Foreground = Brushes.Red;
            else
                textBlockNotifications.Foreground = Brushes.Green;
            textBlockNotifications.Text = message;
            if (message == "")
                lblNotifications.Visibility = Visibility.Hidden;
            else
                lblNotifications.Visibility = Visibility.Visible;
        }

        public static void SetTopExceptionError(Exception ex, string message)
        {
            if (TopErrorException == null)
            {
                TopErrorException = ex;
                ErrorBoxMessage = message;
            }
        }

        //public void loadxml(recipescontext context)
        //{
        //    listbox_recipes.datacontext = (
        //        from r in context.recipes
        //        select r).include(r => r.ingredients).tolist();
        //}

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (listBox_Recipes.SelectedIndex >= 0)
            //{
            //    Recipe recipe = (Recipe)listBox_Recipes.SelectedItem;
            //    textBox_RecipeType.Text = "• Recipe Type  :  " + recipe.RecipeType
            //                                + "\n• Yield  :  " + recipe.Yield
            //                                + "\n\n• Serving Size  :\n" + recipe.ServingSize;
            //    textBox_Directions.Text = recipe.Directions.Trim();
            //    textBox_Comments.Text = recipe.Comment?.Trim();

            //    StringBuilder ing_txt = new StringBuilder();
            //    foreach (var ing in recipe.Ingredients)
            //    {
            //        ing_txt.Append(ing.Description).Append('\n');
            //    }
            //    textBox_Ingredients.Text = ing_txt.ToString();
            //    SetMessageBox("");
            //}
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                validWindowClose = true;
                this.Close();
            }
            finally
            {
                validWindowClose = false;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!validWindowClose)
            {
                e.Cancel = true;
                SetMessageBox("Please use the 'Exit' button on the form", false);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshForm();
            SetMessageBox("");
        }

        private void RefreshForm()
        {
            using (RecipesContext context = new RecipesContext())
            {
                //listBox_Recipes.DataContext = (
                //           from r in context.Recipes
                //           select r).Include(r => r.Ingredients).ToList();
                Vm.Recipes = Vm.FillRecipe();
                RefreshContents();
            }
        }

        private void RefreshContents()
        {
            listBox_Recipes.SelectedIndex = -1;
            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
            
            //textBox_RecipeType.Text = textBox_Directions.Text = lstVw_Ingredients.Text = textBox_Comments.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchDialogBox dialog = new SearchDialogBox();
            #region SearchDialogBox Initialization
            dialog.Title = this.Title;
            dialog.Left = this.Left + (this.Width / 2) - (dialog.Width / 2);
            dialog.Top = this.Top + (this.Height / 2) - (dialog.Height / 2);
            #endregion
            if ((bool)dialog.ShowDialog())
            {
                Vm.Recipes = new ObservableCollection<Recipe>();
                foreach (var r in dialog.foundRecipes) {
                    ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
                    foreach (var ing in r.Ingredients) {
                        ingredients.Add(ing);
                    }
                    switch (r.RecipeType.Trim()) {
                        case "Meal Item":
                            Vm.Recipes.Add(new MealItem { RecipeID = r.RecipeID, Title = r.Title, RecipeType = "Meal Item", Yield = r.Yield, ServingSize = r.ServingSize, Directions = r.Directions, Comment = r.Comment, Ingredients = ingredients });
                            break;
                        case "Dessert":
                            Vm.Recipes.Add(new Dessert { RecipeID = r.RecipeID, Title = r.Title, RecipeType = "Dessert", Yield = r.Yield, ServingSize = r.ServingSize, Directions = r.Directions, Comment = r.Comment, Ingredients = ingredients });
                            break;
                    }
                }
                if (dialog.foundRecipes.Count != 0)
                {
                    SetMessageBox($"Found {dialog.foundRecipes.Count} recipes with search criteria: {dialog.searchInputTextBox.Text}", true);
                }
                else if (dialog.searchInputTextBox.Text.Trim() != "")
                {
                    SetMessageBox($"No recipes were found with search criteria: {dialog.searchInputTextBox.Text}");
                }

            }
            else
                SetMessageBox("");
            //RefreshContents();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            NewRecipe newRecipeWindow = new NewRecipe();
            
            if ((bool)newRecipeWindow.ShowDialog())
            {

            }

        }

        private void listBox_Recipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox_Recipes.SelectedIndex >= 0)
            {
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
