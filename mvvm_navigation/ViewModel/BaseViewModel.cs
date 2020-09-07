using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace mvvm_navigation.ViewModel
{
    /// <summary>
    /// A base implementation of a view model
    /// </summary>
    /// <remarks> Handles OnPropertyChanged() </remarks>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region On Property Changed Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion On Property Changed Implementation
    }
}