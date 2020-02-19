using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmailParserWPF.ViewModels.Commands
{
    public class ExitApplicationCommand : ICommand
    {
        

        public ExitApplicationCommand()
        {
            
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; //temporary
        }

        public void Execute(object parameter)
        {
            Environment.Exit(0);
        }
    }
}
