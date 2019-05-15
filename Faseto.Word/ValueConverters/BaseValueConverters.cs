using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Faseto.Word.ValueConverters
{
    /// <summary>
    /// A base value converter  that allows direct XAML usage.
    /// </summary>
    /// <typeparam name="T">The type of this value converter</typeparam>


   
    public abstract class BaseValueConverters<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        #region PrivateMethods

        private static T _converter = null;

        #endregion



        #region Markup Extensions

        /// <summary>
        /// Provides a static instance of the service provider
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }

        #endregion

        #region PublicMethods

        /// <summary>
        /// The method to convert one value to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// The method to convert a value back to its source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}