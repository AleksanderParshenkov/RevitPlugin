using Autodesk.Revit.UI;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RevitPlugin
{
    internal static class ImageMethods
    {
        public static BitmapImage Convert(Image img)
        {
            using (var memory = new MemoryStream())
            {
                img.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitMapImage = new BitmapImage();
                bitMapImage.BeginInit();
                bitMapImage.StreamSource = memory;
                bitMapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitMapImage.EndInit();
                return bitMapImage;
            }
        }

        public static void AddImageToButtonData(PushButtonData newButtonData, Image img)
        {
            ImageSource imageSource = ImageMethods.Convert(img);
            newButtonData.LargeImage = imageSource;
            newButtonData.Image = imageSource;
        }
    }
}
