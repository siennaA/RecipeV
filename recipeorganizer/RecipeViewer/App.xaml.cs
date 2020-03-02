using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RecipesEDM;


namespace RecipeViewer {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public App() : base(){
            Database.SetInitializer<RecipesContext>(new RecipesDBInitializer());
        }
    }
}
