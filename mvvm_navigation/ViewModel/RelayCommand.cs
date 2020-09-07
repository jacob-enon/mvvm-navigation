using System;
using System.Windows.Input;

namespace mvvm_navigation.ViewModel
{
    /// <summary>
    /// Initializes a new instance of a RelayCommand
    /// </summary>
    /// <typeparam name="T"> Type of the command </typeparam>
    /// <remarks> Facilitates relaying commands between views and view models </remarks>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Predicate<T> canExecute;

        /// <summary>
        /// Event handler for changing status of CanExecute
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Instantiate a new instance of a RelayCommand that can always execute
        /// </summary>
        /// <param name="execute"> Action to execute </param>
        public RelayCommand(Action<T> execute) : this(execute, x => true) { }

        /// <summary>
        /// Instantiate a RelayCommand with a CanExecute predicate
        /// </summary>
        /// <param name="execute"> If the action can be executed </param>
        /// <param name="canExecute"> Action to execute </param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Evaluates the canExecute predicate
        /// </summary>
        /// <param name="parameter"> Parameter to determine CanExecute </param>
        /// <returns> True if can execute </returns>
        public bool CanExecute(object parameter) => canExecute((T)parameter);

        /// <summary>
        /// Executes the associated action
        /// </summary>
        /// <param name="parameter"> Parameter to execute with </param>
        public void Execute(object parameter)
        {
            execute((T)parameter);
        }
    }
}