INDX( 	 o,n           (   8   �       U xt  ngdi= � +                    �     AE��h=�@��h=�@��h=�@��h=�                      s c . u s e r _ i n j e c t e d . 1 . e t l                �     AE��h=�@��h=�@��h=�@��h=�                      S C U S E R ~ 2 . E T L                     p Z     �     AE��h=�@��h=�@��h=�@��h=�                      S C U S E R ~ 2 . E T L                     �     AE��h=�@��h=�@��h=�@��h=�                      S C  S E R ~ 2 . E T L                     �     ���h=�ɰ�h=�ɰ�h=�ɰ�h=�                      S C U S E R ~ 3 . E T L                     �     ���h=�ɰ�h=�ɰ�h=�ɰ�h=�                      S C U S E R ~ 3 . E T L                     d) ? true : false;
        }

        public bool checkTel(string tel)
        {

            Regex ex = new Regex(telPatterrn);
            return ex.IsMatch(tel) ? true : false;
        }




        public string MD5Hash(string te )
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
               strBuilder.Append(result[i].ToString("x2"));
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
            // Create two different encodi s.
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
            Encoding ut = Enco ng.GetEncoding(874); // 874 for Thai langauge
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
                mCard  (IntPtr)res;
            return mCard;
        }
        public String ConvertDate(String date)
        {
            DateTime newDate = DateTime.Parse(date);
            return newDate.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public String _yyyymmdd_(String d)
        {
            string s = "";
            string _yyyy = d.Substring(0, 4);
            string _mm = d.Substring(4, 2);
            string _dd = d.Substring(6, 2);


            string[] mm = { "", "ม.ค.", "ก. �.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธ.ค." };
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

            s = _dd + " " + _tm + " "  _yyyy;
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
