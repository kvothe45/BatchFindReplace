using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace BatchFindReplace
{
    class FileNumbering
    {
        string searchFor;
        string replaceWith;

        public static void AddNumbers()
        {
            FileNumbering app = new FileNumbering();
            string directoryPath = @"C:\Users\Ralph\Documents\test\";
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            FileInfo[] files = directory.GetFiles();
            int count = 0;
            int arrayLenght = files.Length;
            foreach (FileInfo element in files)
            {
                count += 1;
                string s = Convert.ToString(count);
                if (arrayLenght > 98)
                {
                    if (count < 10)
                    {
                        File.Move(directoryPath + element, directoryPath + "00" + s + " " + element);
                        //Console.WriteLine(directoryPath + tempString);
                    }
                    else if (count < 100)
                    {
                        File.Move(directoryPath + element, directoryPath + "0" + s + " " + element);
                        //Console.WriteLine(directoryPath +  tempString);
                    }
                    else
                    {
                        File.Move(directoryPath + element, directoryPath + s + " " + element);
                    }
                    //Console.WriteLine("file {0}:  {1}", count, element);
                }
                else
                {
                    if (count < 10)
                    {
                        File.Move(directoryPath + element, directoryPath + "0" + s + " " + element);
                        //Console.WriteLine(directoryPath + tempString);
                    }
                    else
                    {
                        File.Move(directoryPath + element, directoryPath + s + " " + element);
                        //Console.WriteLine(directoryPath +  tempString);
                    }
                }
            }
        }

        public static void RemoveNumbers()
        {
            FileNumbering app = new FileNumbering();
            string directoryPath = @"C:\Users\Ralph\Documents\test\";
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            FileInfo[] files = directory.GetFiles();
            int count = 0;
            int arrayLenght = files.Length;
            string tempString = null;
            foreach (FileInfo element in files)
            {
                count += 1;
                string s = Convert.ToString(count);
                tempString = element.ToString();
                if (arrayLenght > 98)
                {
                    if (count < 10)
                    {

                        app.searchFor = "00" + s + " ";
                        app.replaceWith = "";
                        tempString = Regex.Replace(tempString, app.searchFor, app.replaceWith, RegexOptions.IgnoreCase);
                        File.Move(directoryPath + element, directoryPath + tempString);
                        //Console.WriteLine(directoryPath + tempString);
                    }
                    else if (count < 100)
                    {
                        app.searchFor = "0" + s + " ";
                        app.replaceWith = "";
                        tempString = Regex.Replace(tempString, app.searchFor, app.replaceWith, RegexOptions.IgnoreCase);
                        File.Move(directoryPath + element, directoryPath + tempString);
                        //Console.WriteLine(directoryPath +  tempString);
                    }
                    else
                    {
                        app.searchFor = s + " ";
                        app.replaceWith = "";
                        tempString = Regex.Replace(tempString, app.searchFor, app.replaceWith, RegexOptions.IgnoreCase);
                        File.Move(directoryPath + element, directoryPath + tempString);
                        //Console.WriteLine(directoryPath +  tempString);
                    }
                }
                else
                {
                    if (count < 10)
                    {

                        app.searchFor = "0" + s + " ";
                        app.replaceWith = "";
                        tempString = Regex.Replace(tempString, app.searchFor, app.replaceWith, RegexOptions.IgnoreCase);
                        File.Move(directoryPath + element, directoryPath + tempString);
                        //Console.WriteLine(directoryPath + tempString);
                    }
                    else
                    {
                        app.searchFor = s + " ";
                        app.replaceWith = "";
                        tempString = Regex.Replace(tempString, app.searchFor, app.replaceWith, RegexOptions.IgnoreCase);
                        File.Move(directoryPath + element, directoryPath + tempString);
                        //Console.WriteLine(directoryPath +  tempString);
                    }
                }
                //Console.WriteLine("file {0}:  {1}", count, element);
            }
        }

        // Custom match method called by Regex.Replace
        // using System.Text.RegularExpressions
        string ReplaceMatchCase(Match m)
        {
            // Test whether the match is capitalized
            if (Char.IsUpper(m.Value[0]) == true)
            {
                // Capitalize the replacement string
                // using System.Text;
                StringBuilder sb = new StringBuilder(replaceWith);
                sb[0] = (Char.ToUpper(sb[0]));
                return sb.ToString();
            }
            else
            {
                return replaceWith;
            }
        }
    }
}
