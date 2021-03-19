using System;
using System.IO;
using System.Collections.Generic;

namespace solutionToKasperskyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            FileProcessor fp = new FileProcessor(new HtmlHandler());
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
            fp.ProcessFile(@"C:\Users\777\Desktop\test");               // Test for a file that does not exist. Console should return "File does not exist.".
            
            fp.fileHandler = new TextHandler();
            fp.ProcessFile(@"C:\Users\777\Desktop\test.json");              // Test for valid files sent to wrong handler. Console should return 
                                                                            // "You are trying to pass a valid file to an incorrect handler."
        }
    }


    public abstract class AbstractFileHandler
    {
        List<string> SupportedExtensions = new List<string>() {".html",".txt",".json"};
        public string TheFileExtension;

        public void FileHandler(string fileName)
        {
            if (File.Exists(fileName))
            {
                TheFileExtension = Path.GetExtension(fileName);
                if (SupportedExtensions.Contains(TheFileExtension))
                {
                    if(TheFileExtension.Contains(ValidExtensionForMethod()))
                    {
                        DoSomeStuff(fileName);
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
        protected abstract void DoSomeStuff(string fileName);

        protected abstract string ValidExtensionForMethod();
    }

    public class FileProcessor
    {
        public AbstractFileHandler fileHandler;
        public FileProcessor(AbstractFileHandler fileHandler) => this.fileHandler = fileHandler;
        public void ProcessFile(string fileName)
        {
            fileHandler.FileHandler(fileName);
        }
    }

    class HtmlHandler : AbstractFileHandler
    {
        protected override string ValidExtensionForMethod() => ".html";
        protected override void DoSomeStuff(string fileName)
        {
            Console.WriteLine("Html file handled");
        }
    }

    class TextHandler : AbstractFileHandler
    {
        protected override string ValidExtensionForMethod() => ".txt";
        protected override void DoSomeStuff(string fileName)
        {
            Console.WriteLine("Text file handled");
        }
    }

    class JsonHandler : AbstractFileHandler
    {
        protected override string ValidExtensionForMethod() => ".json";
        protected override void DoSomeStuff(string fileName)
        {
            Console.WriteLine("JSON file handled");
        }
    }
}
