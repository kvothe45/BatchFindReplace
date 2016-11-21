using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace BatchFindReplace
{
    class SearchClass
    {

        public static void FindReplace(string folderPath, string searchString, string replaceString, int charBefore, int charAfter)
        {
            // Get the index of the search string and then add or subtract from that index

            //create a directory info object and assign it the name directory
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            //create a FileInfo array that is filled with the listing of the directory
            FileInfo[] files = directory.GetFiles();
            //create the 2 dimensional array that will store the filename in one portion and the file extension in the other
            //this will be 2 wide and as deep as the number of files in the directory
            string[,] tempFiles = new string[2, files.Length];
            //this creates the variable that will be used for the rest of method.  they are created here so that each time
            //through the for loop they aren't being re-instantiated
            int tempExtensionLength, indexStart, indexEnd, count = 0;
            string tempFileName;

            //this foreach statement is going to be used to split the files in the directory apart separating the filename
            //from the file extension
            foreach (FileInfo element in files)
            {
                //given the variety of extensions out there, this finds the length of the extension starting at the period
                //so extension name +1
                tempExtensionLength = element.Extension.Length;

                //the next two lines put the full filename into a sting and then removes the extension from that string
                //including the . element
                tempFileName = element.ToString();
                tempFileName = tempFileName.Remove(tempFileName.Length - tempExtensionLength);

                //we are putting the filename into a 2 x however many files are in the directory array split by 
                //filename and file extension for easier handling and sorting
                tempFiles[0, count] = tempFileName;
                tempFiles[1, count] = element.Extension.ToString();

                //increment the count making it a total of 1 larger than the length of the array when the foreach loop exits
                count++;
            }

            //runs through the array and removes the requested portion of the string 
            for (int i = 0; i < count; i++)
            {
                tempFileName = tempFiles[0, i];

                //this gets the start position of the text i want to find
                //returns -1 if searchString isn't found
                indexStart = tempFileName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase);

                //skips the whole find replace element if the index didn't find a search match from line above
                if (indexStart >= 0)
                {
                    //first step in a 3 step problem remove find string and characters after
                    //removes the requested string from the filename as well as the requested number of 
                    //characters from the front or rear of the requested string
                    indexEnd = searchString.Length + charAfter;
                    tempFileName = tempFileName.Remove(indexStart, indexEnd);

                    //second step is remove characters before
                    indexStart = indexStart - charBefore;
                    indexEnd = charBefore;
                    tempFileName = tempFileName.Remove(indexStart, indexEnd);

                    //third step is to insert the replace string
                    tempFileName = tempFileName.Insert(indexStart, replaceString);

                    //this renames the original filename to the new one we just created.  there is no rename
                    //function so we are just moving the file to the same folder under a different name
                    File.Move(folderPath + "\\" + files[i], folderPath + "\\" + tempFileName + tempFiles[1, i]);
                }

            }

        }
    }
}
