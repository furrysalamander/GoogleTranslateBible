using System;
using System.IO;
using System.Text;


namespace GoogleTranslateBible
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding("Windows-1255");

            // This is your target directory.  This should have the files from the Tanach archive.
            string targetDirectory = @"C:\Users\furry\Documents\Google Translate\";

            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                string outPath = fileName.Replace("Google Translate", "Google Translate 2");
                Console.WriteLine(fileName);
                string line;
                // Read the file and display it line by line.  
                using (System.IO.StreamReader file = new System.IO.StreamReader(fileName))
                {
                    string startChars = file.ReadLine().Substring(0, 3);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Substring(1, 4) == "xxxx")
                        {
                            if (line.Length >= 14)
                            {
                                Console.WriteLine(line);
                                using (System.IO.StreamWriter output = new System.IO.StreamWriter(outPath, true))
                                {
                                    output.WriteLine(line);
                                }
                            }
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
                }
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
