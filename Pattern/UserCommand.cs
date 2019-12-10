using System;
using System.Windows.Input;

namespace ReferenceForDisciplines.Pattern
{
    internal class UserCommand : ICommand
    {
        private readonly Action _func;

        public UserCommand(Action func)
        {
            this._func = func;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _func();
        }

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}