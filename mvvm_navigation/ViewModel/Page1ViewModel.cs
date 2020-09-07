using System.Windows.Input;

namespace mvvm_navigation.ViewModel
{
    /// <summary>
    /// View model for page 1
    /// </summary>
    public class Page1ViewModel : BaseViewModel
    {
        /// <summary>
        /// Navigate to page 2
        /// </summary>
        public ICommand NavigatePage2 => new RelayCommand<object>(x => Mediator.Notify("NavigatePage2", ""));
    }
}