using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Design;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Collections;
namespace BIGCarParkSystem.Class
{
    class Barcode
    {
        public static int CheckSumBarcode(String BarcodeText)
        {
            int sumOod = 0;
            int sumEven = 0;
            int sumAll = 0;
            for (int i = 0; i < 11; i += 2)
            {

                sumOod += (int)Char.GetNumericValue(BarcodeText[i]);

            }
            for (int i = 1; i < 12; i += 2)
            {

                sumEven += (int)Char.GetNumericValue(BarcodeText[i]);

            }
            int remain = ((sumOod + (sumEven * 3)) % 10);
            if (remain == 0)
            {
                sumAll = 0;
            }
            else
            {
                sumAll = 10 - remain;
            }

            return sumAll;
        }
       
        public static String GenBarcodeImg(String Barcode)
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
            {
                IncludeLabel = true,
                Alignment = BarcodeLib.AlignmentPositions.CENTER,
                Width = 230,
                Height = 100,
                RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                BackColor = Color.White,
                ForeColor = Color.Black,

            };
            Image img = barcode.Encode(BarcodeLib.TYPE.EAN13, Barcode);
            String path = Application.StartupPath + "/tempBarcode";
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            String Filename = path + "/" + Barcode + ".jpg";
            String Filename_nopath = Barcode + ".jpg";
            img.Save(Filename, System.Drawing.Imaging.ImageFormat.Jpeg);

            return Filename;

        }

    }
}
