using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.AccessControl;

using System.Security.Principal;


namespace BIGCarParkSystem.Class
{
    class VariableDB
    {
        public static string ServerIp = "";//"localhost";
        public static string Username      = "root";
        public static string PassWord      = "db#local@127";
        public static string Database = "";//"big_carpark";


        public static string PathImage = Application.StartupPath + @"/camera/";
        public static string PathIdCardImage = Application.StartupPath + @"/imagesidcard/";
        public static string PathBarcodeImage = Application.StartupPath + @"/tempBarcode/";

        public static string ConfigFile =  Application.StartupPath + @"\config\server.big";

        public static int TimeAlert = 1000 * 60 * 30;
        public static string printlogo = "";
        public static void ReadConfig()
        {
            string[] configs = System.IO.File.ReadAllLines(VariableDB.ConfigFile);
            if (configs.Length > 0)
            {
                foreach (string line in configs)
                {
                    // Use a tab to indent each line of the file.
                    string[] text = line.Split('=');
                    Console.WriteLine(text[1]);
                    if(text[1] != null )
                    {
                        if(text[0] == "alertTime")
                        {
                            VariableDB.TimeAlert =  Int32.Parse(text[1]);
                        }

                        if (text[0] == "printlogo")
                        {
                            VariableDB.printlogo = (text[1].ToString().Trim());
                        }
                        if (text[0] == "db_ip")
                        {
                            VariableDB.ServerIp = (text[1].ToString().Trim());
                        }
                        if (text[0] == "db_user")
                        {
                            VariableDB.Username = (text[1].ToString().Trim());
                        }
                        if (text[0] == "db_pass")
                        {
                            VariableDB.PassWord = (text[1].ToString().Trim());
                        }
                        if (text[0] == "db_name")
                        {
                            VariableDB.Database = (text[1].ToString().Trim());
                        }
                    }
                }

                //VariableDB.GrantAccess(VariableDB.PathImage);
                //VariableDB.GrantAccess(VariableDB.PathIdCardImage);
                //VariableDB.GrantAccess(VariableDB.PathBarcodeImage);
            }

           
        }
        public static void GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
           
        }
    }

    
}
