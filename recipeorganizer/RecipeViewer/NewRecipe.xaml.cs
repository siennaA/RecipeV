﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
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
    /// Interaction logic for NewRecipe.xaml
    /// </summary>
    public partial class NewRecipe : Window
    {
        private Recipe _newRecipe;
        private List<string> _newIngredientList;

        public NewRecipe()
        {
            InitializeComponent();
            _newRecipe = new Recipe();
            _newIngredientList = new List<string>();
            lstVw_RecipeType.Items.Add("Meal Item");
            lstVw_RecipeType.Items.Add("Dessert");
            lstVw_RecipeType.SelectedItem = -1;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _newRecipe.Title = textBox_RecipeTitle.Text;
            _newRecipe.RecipeType = (lstVw_RecipeType.SelectedIndex >= 0) ? lstVw_RecipeType.SelectedItem.ToString() : ""; ;
            _newRecipe.Yield = textBox_RecipeYield.Text;
            _newRecipe.ServingSize = textBox_RecipeServingSize.Text;
            _newRecipe.Directions = textBox_RecipeDirections.Text;
            _newRecipe.Comment = textbox_RecipeComment.Text;

            Collection<Ingredient> ingredients = new Collection<Ingredient>();
            foreach (var item in lstVw_Ingredients.Items)
            {
                ingredients.Add(new Ingredient { Description = item.ToString(), Recipe = _newRecipe });
            }

            _newRecipe.Ingredients = ingredients;
            string msg;
            bool success = ((MainWindow)this.Owner).Vm.AddRecipe(_newRecipe, out msg);
            if (success)
            {
                textBox_RecipeTitle.Text = "";
                lstVw_RecipeType.SelectedIndex = -1;
                textBox_RecipeYield.Text = "";
                textBox_RecipeServingSize.Text = "";
                textBox_RecipeDirections.Text = "";
                lstVw_Ingredients.Items.Clear();
                textbox_RecipeComment.Text = "";

                ((MainWindow)this.Owner).Vm.FillRecipe();
            }
            MessageBox.Show(msg, "Error");
        }
    

        private void Btn_AddIngredent_Click(object sender, RoutedEventArgs e)
        {
            //_newIngredientList.Add(textBox_Ingredient.Text);   
            string addto = textBox_Ingredient.Text.Trim();
            if (!String.IsNullOrEmpty(addto))
            {
                lstVw_Ingredients.Items.Add(addto);
                textBox_Ingredient.Text = "";
                Btn_AddIngredent.IsEnabled = false;
            }
        }

        private void Btn_DelIngredent_Click(object sender, RoutedEventArgs e)
        {
            if (lstVw_Ingredients.SelectedIndex >= 0)
            {
                //_newIngredientList.RemoveAt(lstVw_Ingredients.SelectedIndex);
                lstVw_Ingredients.Items.Remove(lstVw_Ingredients.SelectedItem);
            }
            Btn_DelIngredent.IsEnabled = false;
            
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

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            textBox_RecipeTitle.Text = "";
            lstVw_RecipeType.SelectedIndex = -1;
            textBox_RecipeYield.Text = "";
            textBox_RecipeServingSize.Text = "";
            textBox_RecipeDirections.Text = "";
            lstVw_Ingredients.Items.Clear();
            textbox_RecipeComment.Text = "";
        }
    }
}
