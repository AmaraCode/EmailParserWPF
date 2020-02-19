using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmailParserWPF.ViewModels.Commands
{
    public class ExportToFileCommand : ICommand
    {
        private Action<IList<string>> _execute;

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="execute"></param>
        public ExportToFileCommand(Action<IList<string>> execute)
        {
            _execute = execute;

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; //temporary
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter as IList<string>);

        }
    }
}
