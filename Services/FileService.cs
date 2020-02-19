using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EmailParserWPF.Services
{
    public class FileService
    {


        public FileService()
        {

        }


        public static FileService CreateNew()
        {
            return new FileService();
        }



        public bool SaveList(string filename, IList<string> emails)
        {

            bool success = false;

            if (filename == "") { return false; }


            var info = new FileInfo(filename);

            if(info.Extension.ToLower() == ".json")
            {
                var io = new AmaraCode.FileIO();
                success = io.SaveCollection<IList<string>>(emails, filename);
}
            else if(info.Extension.ToLower() == ".txt")
            {
                System.IO.File.WriteAllLines(filename, emails);
                success = true;
            }

            return success;

        }


    }
}
