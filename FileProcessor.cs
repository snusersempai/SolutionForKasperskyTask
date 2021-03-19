using System;
using System.IO;
using System.Collections.Generic;

namespace solutionToKasperskyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            FileProcessor fp = new FileProcessor(new HtmlHandler());        // Declaring object of type class FileProcessor
            fp.ProcessFile(@"C:\Users\777\Desktop\test.html");              // Test for html file handling. Console should return "Html file handled".

            fp.fileHandler = new TextHandler();                             
            fp.ProcessFile(@"C:\Users\777\Desktop\test.txt");               // Test for text file handling. Console should return "Text file handled".

            fp.fileHandler = new JsonHandler();                             
            fp.ProcessFile(@"C:\Users\777\Desktop\test.json");              // Test for JSON file handling. Console should return "JSON file handled".

            fp.fileHandler = new JsonHandler();                                  
            fp.ProcessFile(@"C:\Users\777\Desktop\test.xml");               // Test for a file with unsupported extension input. Console should return 
                                                                            // "The extension you try to work with is not supported yet." and
                                                                            // "To work with " + TheFileExtension + " files check the Readme file"

            fp.fileHandler = new JsonHandler();                             
            fp.ProcessFile(@"C:\Users\777\Desktop\test");                   // Test for a file that does not exist. Console should return "File does not exist.".
            
            fp.fileHandler = new TextHandler();
            fp.ProcessFile(@"C:\Users\777\Desktop\test.json");              // Test for valid files sent to wrong handler. Console should return 
                                                                            // "You are trying to pass a valid file to an incorrect handler."
        }
    }


    public abstract class AbstractFileHandler                                                                               
    {
        List<string> SupportedExtensions = new List<string>() {".html",".txt",".json"};                                     //List of supported extensions
        public string TheFileExtension;

        public void FileHandler(string fileName)
        {
            if (File.Exists(fileName))                                                                                      //Check does the file exist or not
            {
                TheFileExtension = Path.GetExtension(fileName);                                                             //Get the extension of file
                if (SupportedExtensions.Contains(TheFileExtension))                                                         
                {
                    if(TheFileExtension.Contains(ValidExtensionForMethod()))                                                //Check if the file from handler suits its extension
                    {
                        DoSomeStuff(fileName);                                                                              //Calling function that overrided in specific handler
                    }
                    else
                    {
                        Console.WriteLine("You are trying to pass a valid file to an incorrect handler.");
                    }
                }
                else
                {
                    Console.WriteLine("The extension you try to work with is not supported yet.");
                    Console.WriteLine("To work with " + TheFileExtension + " files check the Readme file");
                }  
            }   
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        protected abstract void DoSomeStuff(string fileName);                                                               //Declaring abstract function for work with file

        protected abstract string ValidExtensionForMethod();                                                                //Declaring abstract string for suitable extensions
                                                                                                                            //from handlers
    }

    public class FileProcessor                                                                                              // FileProcessor class
    {
        public AbstractFileHandler fileHandler;
        public FileProcessor(AbstractFileHandler fileHandler) => this.fileHandler = fileHandler;                            //Qualifying the members of the class
        public void ProcessFile(string fileName)
        {
            fileHandler.FileHandler(fileName);                                                                              //Calling the file handler form abstract class
        }
    }

    class HtmlHandler : AbstractFileHandler                                                                                 // HtmlHandler class
    {
        protected override string ValidExtensionForMethod()
        {
            return ".html";                                                                                                 // Overriding the ValidExtensonForMethod()
        }                                                     
        protected override void DoSomeStuff(string fileName)                                                                // Some process with file
        {
            Console.WriteLine("Html file handled");
        }
    }

    class TextHandler : AbstractFileHandler                                                                                 // TextHandler class
    {
        protected override string ValidExtensionForMethod()
        {
            return ".txt";                                                                                                  // Overriding the ValidExtensonForMethod()
        }
        protected override void DoSomeStuff(string fileName)                                                                // Some process with file
        {
            Console.WriteLine("Text file handled");
        }
    }

    class JsonHandler : AbstractFileHandler                                                                                 // JsonHandler class
    {
        protected override string ValidExtensionForMethod()
        {
            return ".json";                                                                                                 // Overriding the ValidExtensonForMethod()
        }
        protected override void DoSomeStuff(string fileName)                                                                // Some process with file
        {
            Console.WriteLine("JSON file handled");
        }
    }
}
