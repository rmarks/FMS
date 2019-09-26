using System.IO;

namespace FMS.WPF.ViewModel.Helpers
{
    public class PictureLocationHelper
    {
        public static string GetPictureLocation(string productBaseCode)
        {
            string path = @"C:\abd\fms\pildid\vpildid\";
            string blankPicturePath = path + "BlankImage.png";

            if (productBaseCode == null)
            {
                return blankPicturePath;
            }

            string picturePath = path + productBaseCode.Trim() + ".jpg";
            if (!File.Exists(picturePath))
            {
                picturePath = null;
            }

            return picturePath ?? blankPicturePath; ;
        }
    }
}
