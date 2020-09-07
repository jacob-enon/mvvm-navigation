using System.Windows.Input;

namespace mvvm_navigation.ViewModel
{
    /// <summary>
    /// View model for page 2
    /// </summary>
    public class Page2ViewModel : BaseViewModel
    {
        /// <summary>
        /// Navigate to page 1
        /// </summary>
        public ICommand NavigatePage1 => new RelayCommand<object>(x => Mediator.Notify("NavigatePage1", ""));
    }
}