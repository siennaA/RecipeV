using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace RecipeViewer
{
    class Startup
    {
        [System.STAThreadAttribute()]
        static void Main()
        {
            try
            {
                RecipeViewer.App app = new RecipeViewer.App();

                app.InitializeComponent();
                app.Run();
            }
            //catches inner exptions and passes to recursive method to get to the core golden nugget excption
            catch (AggregateException ex)
            {
                foreach (Exception inner in ex.Flatten().InnerExceptions)
                {
                    if (inner.InnerException != null)
                    {
                        GoldenNuggetException(inner.InnerException);
                    }
                }
            }
            //this catch catches all the excptions that are thrown in main.
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    GoldenNuggetException(ex.InnerException);
                }
                MainWindow.SetTopExceptionError(ex, ex.Message);
            }

        }
        public static void GoldenNuggetException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                GoldenNuggetException(ex.InnerException);
            }
            else
            {
                MainWindow.SetTopExceptionError(ex, ex.Message);
            }
        }
    }
}
