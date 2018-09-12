using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Google.Cloud.Translation.V2;


namespace GoogleTranslateBible
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");

            string targetDirectory = @"C:\Users\furry\Documents\Google Translate\";

            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                string outPath = fileName.Replace("Google Translate", "Google Translate 2");
                Console.WriteLine(fileName);
                string line;
                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(fileName);
                string startChars = file.ReadLine().Substring(0, 3);
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Substring(1, 4) == "xxxx")
                        if (line.Length >= 14)
                        {
                            Console.WriteLine(line);
                            using (System.IO.StreamWriter output = new System.IO.StreamWriter(outPath, true))
                            {
                                output.WriteLine(line);
                            }

                        }
                        else
                        {

                        }
                    else
                    {
                        Console.WriteLine(line);
                        string outLine = Translate(line/*.Substring(9,line.Length-9)*/, "en", "iw");
                        Console.WriteLine(outLine);
                        using (System.IO.StreamWriter output = new System.IO.StreamWriter(outPath, true))
                        {
                            output.WriteLine(outLine);
                        }
                        Console.WriteLine();
                    }
                }

                file.Close();
            }
            Console.ReadLine();

        }
        static string Translate(string text, string targetLanguageCode, string sourceLanguageCode)
        {
            ///*
            TranslationClient client = TranslationClient.Create();
            var response = client.TranslateText(text, targetLanguageCode,
                sourceLanguageCode);
            return response.TranslatedText;
            //*/
            //return text;
        }
    }
}
