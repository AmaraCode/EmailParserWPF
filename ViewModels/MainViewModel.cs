using EmailParserWPF.Services;
using EmailParserWPF.ViewModels.Commands;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmailParserWPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private string _textToParse;
        public string TextToParse
        {
            get { return _textToParse; }
            set
            {
                _textToParse = value;
                OnPropertyChanged();
            }
        }

        private IList<string> _emails;
        public IList<string> Emails
        {
            get { return _emails; }
            set
            {
                _emails = value;
                EmailCountLabel = _emails.Count > 0 ? $"{_emails.Count} Emails Found" : "No Emails Found";
                OnPropertyChanged();
            }
        }

        private string _emailCountLabel = "No Emails Found";
        public string EmailCountLabel
        {
            get
            { return _emailCountLabel; }
            set
            {
                _emailCountLabel = value;
                OnPropertyChanged();
            }
        }

          
        public ClearCommand ClearCommand { get; private set; }
        public ParseEmailTextCommand ParseCommand { get; private set; }
        public ExitApplicationCommand ExitApplicationCommand { get; private set; }
        public ExportToFileCommand ExportToFileCommand { get; private set; }
        private EmailParseService _emailService;
        private FileService _fileService;
        


        /// <summary>
        /// 
        /// </summary>
        public MainViewModel()
        {
            ClearCommand = new ClearCommand(ClearScreen);
            ParseCommand = new ParseEmailTextCommand(ParseText);
            ExitApplicationCommand = new ExitApplicationCommand();
            ExportToFileCommand = new ExportToFileCommand(ExportToFile);
            _emailService = EmailParseService.CreateNew();
            _fileService = FileService.CreateNew();

        }



        private void ClearScreen()
        {
            TextToParse = "";
            Emails = new List<string>();

        }





        /// <summary>
        /// 
        /// </summary>
        private void ParseText()
        {
            if (TextToParse != "")
            {
                IList<string> emails = _emailService.ParseText(TextToParse);
                
                if (emails.Count > 0)
                {
                    Emails = emails;
                }
            }
            else
            {
                Emails = new List<string>();
                //MessageBox.Show("No text to parse.  Try again.");
            }
        }
        




        /// <summary>
        /// 
        /// </summary>
        /// <param name="emails"></param>
        private void ExportToFile(IList<string> emails)
        {
            //if(emails.Count == 0) { return null; }

            SaveFileDialog fd = new SaveFileDialog();
            fd.DefaultExt = "json";
            fd.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";

            bool? dialogResult = fd.ShowDialog();

            if (dialogResult == true)
            {
                if(fd.FileName != "")
                {
                    //we  have a filename to save.
                    _fileService.SaveList(fd.FileName, this.Emails);

                    MessageBox.Show($"{fd.FileName} has been saved.");
                }
            }

            //return null;


        }

    }
}
