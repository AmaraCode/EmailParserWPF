using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EmailParserWPF.Services
{
    public class EmailParseService
    {

        public EmailParseService()
        {

        }



        public IList<string> ParseText(string textToParse)
        {
            var emails = new List<string>();



            Debug.WriteLine("ParseText method called");

            if (textToParse != null)
            { 
                AmaraCode.Text parser = new AmaraCode.Text();
                var list = parser.ParseEmailsFromText(textToParse);
               
                emails.AddRange(list);
            }

            return emails;
        }



        public static EmailParseService CreateNew()
        {
            return new EmailParseService();
        }

    }
}
