using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmailParserWPF.ViewModels.Commands
{
    public class ParseEmailTextCommand : ICommand
    {

        private Action _execute;

        public ParseEmailTextCommand(Action execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return true;  //temporary
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}
