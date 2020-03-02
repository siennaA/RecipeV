using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDataAccess
{
    public class XmlHandler
    {
        public static string XmlBackupDirectory = StorageDirectory();

        private static string StorageDirectory()
        {
            string solutionConfigurationString;
#if DEBUG
            solutionConfigurationString = "Debug";
#else
            solutionConfigurationString = "Release";
#endif
            return "../../../RecipeDataAccess/bin/" + solutionConfigurationString + "/";
        }
    }
}
