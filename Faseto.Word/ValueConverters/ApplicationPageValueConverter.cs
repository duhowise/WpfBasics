using System;
using System.Diagnostics;
using System.Globalization;
using Faseto.Word.DataModels;
using Faseto.Word.Pages;

namespace Faseto.Word.ValueConverters
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view or page
    /// </summary>
    public class ApplicationPageValueConverter:BaseValueConverters<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //find the appropriate page
            if (value != null)
                switch ((ApplicationPage) value)
                {
                    case ApplicationPage.Login:
                        return new LoginPage();

                    default:
                        Debugger.Break();
                        return null;
                }
            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}