using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace BIGCarParkSystem.Resources
{
    class FunctionClass
    {

        private string userPattern = "/^(a-zA-Z0-9)$/";
        public bool checkUsername(string username)
        {

            Regex ex = new Regex(userPattern);
            return ex.IsMatch(username) ? true : false;
        }



        public string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public string getDateNow()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // case sensitive
        }

        public string getRanFile()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss"); // case sensitive
        }


        public byte[] String2Byte(string s)
        {
            // Create two different encodings.
            Encoding ascii = Encoding.GetEncoding(874);
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(s);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            return asciiBytes;
        }
        public string aByteToString(byte[] b)
        {
            Encoding ut = Encoding.GetEncoding(874); // 874 for Thai langauge
            int i;
            for (i = 0; b[i] != 0; i++) ;

            string s = ut.GetString(b);
            s = s.Substring(0, i);
            return s;
        }

        public IntPtr selectReader(String reader)
        {
            IntPtr mCard = (IntPtr)0;
            byte[] _reader = String2Byte(reader);
            IntPtr res = (IntPtr)RDNIDWRAPPER.RDNID.selectReaderRD(_reader);
            if ((Int64)res > 0)
                mCard = (IntPtr)res;
            return mCard;
        }
        public String _yyyymmdd_(String d)
        {
            string s = "";
            string _yyyy = d.Substring(0, 4);
            string _mm = d.Substring(4, 2);
            string _dd = d.Substring(6, 2);


            string[] mm = { "", "ม.ค.", "ก.พ.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธ.ค." };
            string _tm = "-";
            if (_mm == "00")
            {
                _tm = "-";
            }
            else
            {
                _tm = mm[int.Parse(_mm)];
            }
            if (_yyyy == "0000")
                _yyyy = "-";

            if (_dd == "00")
                _dd = "-";

            s = _dd + " " + _tm + " " + _yyyy;
            return s;
        }


        public enum NID_FIELD
        {
            NID_Number,   //1234567890123#

            TITLE_T,    //Thai title#
            NAME_T,     //Thai name#
            MIDNAME_T,  //Thai mid name#
            SURNAME_T,  //Thai surname#

            TITLE_E,    //Eng title#
            NAME_E,     //Eng name#
            MIDNAME_E,  //Eng mid name#
            SURNAME_E,  //Eng surname#

            HOME_NO,    //12/34#
            MOO,        //10#
            TROK,       //ตรอกxxx#
            SOI,        //ซอยxxx#
            ROAD,       //ถนนxxx#
            TUMBON,     //ตำบลxxx#
            AMPHOE,     //อำเภอxxx#
            PROVINCE,   //จังหวัดxxx#

            GENDER,     //1#			//1=male,2=female

            BIRTH_DATE, //25200131#	    //YYYYMMDD 
            ISSUE_PLACE,//xxxxxxx#      //
            ISSUE_DATE, //25580131#     //YYYYMMDD 
            EXPIRY_DATE,//25680130      //YYYYMMDD 
            ISSUE_NUM,  //12345678901234 //14-Char
            END
        };
    }
}
