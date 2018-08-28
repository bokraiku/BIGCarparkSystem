using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BIGCarParkSystem.Class
{
    class VariableDB
    {
        public static string ServerIp      = "localhost";
        public static string Username      = "root";
        public static string PassWord      = "db#local@127";
        public static string Database      = "big_carpark";


        public static string PathImage = Application.StartupPath + @"/";
        public static string PathIdCardImage = Application.StartupPath + @"/imagesidcard/";
        public static string PathBarcodeImage = Application.StartupPath + @"/tempBarcode/";
    }
}
