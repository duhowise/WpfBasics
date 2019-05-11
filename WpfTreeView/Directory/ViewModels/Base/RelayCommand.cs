using System;
using System.Windows.Input;

namespace WpfTreeView.Directory.ViewModels.Base
{/// <summary>
/// A basic command that runs an action
/// </summary>
    public class RelayCommand:ICommand
    {
        private  Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }
        /// <summary>
        /// A Relay Command Can Always Execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
        /// <summary>
        /// Fired when <see cref="CanExecute(object)"/>  changed
        /// </summary>
        public event EventHandler CanExecuteChanged=(sender,eventArgs)=>{};
    }
}