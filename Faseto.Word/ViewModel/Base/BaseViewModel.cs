using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

// ReSharper disable IdentifierTypo

namespace Faseto.Word.ViewModel.Base
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
