using System.Collections.Generic;
using System.Linq;

namespace mvvm_navigation.ViewModel
{
    /// <summary>
    /// Controls displaying and storing viewmodels for the application
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _viewModel;
        /// <summary>
        /// The view model for the current page
        /// </summary>
        public BaseViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel != value)
                {
                    _viewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// All view models in the application
        /// </summary>
        public List<BaseViewModel> ViewModels { get; }

        public MainViewModel() : base(new Mediator())
        {
            ViewModels = new List<BaseViewModel>()
            {
                new Page1ViewModel(Mediator),
                new Page2ViewModel(Mediator)
            };

            ViewModel = ViewModels.First();

            Mediator.Subscribe("NavigatePage1", OnNavigatePage1);
            Mediator.Subscribe("NavigatePage2", OnNavigatePage2);
        }

        private void OnNavigatePage1(object obj)
        {
            ViewModel = ViewModels[0];
        }

        private void OnNavigatePage2(object obj)
        {
            ViewModel = ViewModels[1];
        }
    }
}