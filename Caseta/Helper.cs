using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Caseta
{
    class Helper
    {
        public static void SaveImageDlg(Image image)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.FileName = "Image";
            s.DefaultExt = ".Jpg";
            s.Filter = "Image (.jpg)|*.jpg";

            if (s.ShowDialog() == DialogResult.OK)
                SaveFile(image, s.FileName);
        }

        public static void SaveImage(Image image, string filepath)
        {
            SaveFile(image, filepath);
        }

        private static void SaveFile(Image image, string filepath)
        {
            string filename = filepath;
            FileStream fstream = new FileStream(filename, FileMode.Create);
            image.Save(fstream, ImageFormat.Jpeg);
            fstream.Close();
        }
    }
}
