using System;
using System.Windows.Input;

namespace ReferenceForDisciplines.Pattern
{
    internal class UserCommand : ICommand
    {
        private readonly Action func;

        public UserCommand(Action func)
        {
            this.func = func;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            func();
        }
    }
}