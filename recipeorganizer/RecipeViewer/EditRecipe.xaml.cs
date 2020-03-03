using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using RecipesEDM;

namespace RecipeViewer
{
    /// <summary>
    /// Interaction logic for EditRecipe.xaml
    /// </summary>
    public partial class EditRecipe : Window
    {
        internal Recipe recipe;
        bool saved = true;
        public EditRecipe(Recipe r)
        {
            InitializeComponent();
            recipe = r;
            lstVw_RecipeType.Items.Add("Meal Item");
            lstVw_RecipeType.Items.Add("Dessert");
            ResetForm();
        }

        private void ResetForm()
        {
            textBox_RecipeTitle.Text = recipe.Title;
            switch (recipe.RecipeType.Trim())
            {
                case ("Meal Item"):
                    lstVw_RecipeType.SelectedIndex = 0;
                    break;
                case ("Dessert"):
                    lstVw_RecipeType.SelectedIndex = 1;
                    break;
            }
            textBoxRecipeID_hidden.Text = recipe.RecipeID.ToString();
            textBox_RecipeYield.Text = recipe.Yield;
            textBox_RecipeServingSize.Text = recipe.ServingSize;
            textBox_RecipeDirections.Text = recipe.Directions;
            textbox_RecipeComment.Text = recipe.Comment;

            foreach (var ing in recipe.Ingredients)
            {
                lstVw_Ingredients.Items.Add(ing.Description);
            }
        }

        private void lstVw_Ingredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstVw_Ingredients.SelectedIndex >= 0)
            {
                Btn_DelIngredent.IsEnabled = true;
            }
        }

        private void textBox_Ingredient_TextChanged(object sender, TextChangedEventArgs e)
        {
            Btn_AddIngredent.IsEnabled = true;
        }

        private void Btn_AddIngredent_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox_Ingredient.Text.Trim()))
            {
                lstVw_Ingredients.Items.Add(textBox_Ingredient.Text);
            }
            saved = false;
        }

        private void Btn_DelIngredent_Click(object sender, RoutedEventArgs e)
        {
            if (lstVw_Ingredients.SelectedIndex >= 0)
            {
                lstVw_Ingredients.Items.Remove(lstVw_Ingredients.SelectedItem);
            }
            saved = false;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            if (!saved)
            {
                MessageBox.Show("Recipe Change has not been saved.\n If you Cancel, all the changes will be discarded.");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Recipe toEdit = new Recipe();
            toEdit.RecipeID = recipe.RecipeID;
            toEdit.Title = textBox_RecipeTitle.Text;
            toEdit.RecipeType = lstVw_RecipeType.SelectedItem.ToString();
            toEdit.Yield = textBox_RecipeYield.Text;
            toEdit.ServingSize = textBox_RecipeServingSize.Text;
            toEdit.Comment = textbox_RecipeComment.Text;
            toEdit.Directions = textBox_RecipeDirections.Text;
            toEdit.Ingredients = new Collection<Ingredient>();
            foreach (var ing in lstVw_Ingredients.Items)
            {
                toEdit.Ingredients.Add(new Ingredient { Description = ing.ToString(), Recipe = toEdit });
            }

            string msg;
            if (((MainWindow)this.Owner).Vm.UpdateRecipe(toEdit, out msg))
            {
                saved = true;
                MessageBox.Show(msg, "Update");                
            }
            else
            {
                MessageBox.Show(msg, "Update Error!");
            }
        }
            
        

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string msg;
            if (((MainWindow)this.Owner).Vm.DeleteRecipe((int)(((MainWindow)this.Owner).Vm.SelectedRecipe.RecipeID), out msg))
            {
                saved = true;
                MessageBox.Show(msg, "Delete");
            }
            else
            {
                MessageBox.Show(msg, "Delete Error!");
            }
        }

        private void lstVw_RecipeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            saved = false;
        }

        private void textBox_RecipeTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            saved = false;
        }

        private void textBox_RecipeYield_TextChanged(object sender, TextChangedEventArgs e)
        {
            saved = true;
        }

        private void textBox_RecipeServingSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            saved = true;
        }
    }
}
