using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeView
{
  [ValueConversion(typeof(string),typeof(BitmapImage))]  public class HeaderToImageConverter:IValueConverter
    {
        public static HeaderToImageConverter Instance=new HeaderToImageConverter();
        /// <summary>
        /// Convert a full path to a specific image path
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = value as string??"";

            var name = MainWindow.GetFileFolderName(path);
            var image = "Images/file.png";

            if (string.IsNullOrWhiteSpace(name))
            {
                image = "Images/drive.png";
            }
            else if(new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                image = "Images/folder-closed.png";
            }

           return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}