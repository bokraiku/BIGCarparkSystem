using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIGCarParkSystem.Resources
{
    class UserInfo
    {
        public static string Username;
        public static string UserId;
        public static string UserRole;
        public static string LoginTime;

        

        public static void ClearData()
        {
            UserInfo.LoginTime  = null;
            UserInfo.UserId     = null;
            UserInfo.Username   = null;
            UserInfo.UserRole   = null;
        }
    }

    
}
