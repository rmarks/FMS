using System.IO;

namespace FMS.WPF.ViewModel.Helpers
{
    public class PictureLocationHelper
    {
        public static string GetPictureLocation(string productBaseCode)
        {
            string path = @"C:\abd\fms\pildid\vpildid\";
            string picturePath = path + productBaseCode.Trim() + ".jpg";
            string blankPicturePath = path + "BlankImage.png";

            if (!File.Exists(picturePath))
            {
                picturePath = null;
            }

            return picturePath ?? blankPicturePath; ;
        }
    }
}
