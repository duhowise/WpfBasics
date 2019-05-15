using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WpfTreeView.Directory.Data;

namespace WpfTreeView
{
  [ValueConversion(typeof(DirectotyItemType),typeof(BitmapImage))]  public class HeaderToImageConverter:IValueConverter
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

           
            var image = "Images/file.png";

            switch ((DirectotyItemType)value)
            {
                case DirectotyItemType.Drive:
                    image = "Images/drive.png";
                break;
                case DirectotyItemType.Folder:
                    image = "Images/folder-closed.png";
                    break;
            }
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}