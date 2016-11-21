/********************************************************
*Author:  Ralph E. Beard IV
*Date:  21 November 2016
*Description:  this program goes through the files in a 
* directory and finds the requested text in a filename if
* it exists and replaces it with given text.  if no 
* replace text is given then it just removes the original
* given text.  It will also number or remove numbers from
* the files in the directory
*Revision: 1
********************************************************/
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
/********************************************************
 * License agreement for Ookii.Dialogs.

Copyright © Sven Groot (Ookii.org) 2009
All rights reserved.


Redistribution and use in source and binary forms, with or without 
modification, are permitted provided that the following conditions are met:

1) Redistributions of source code must retain the above copyright notice, 
   this list of conditions and the following disclaimer. 
2) Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution. 
3) Neither the name of the ORGANIZATION nor the names of its contributors
   may be used to endorse or promote products derived from this software
   without specific prior written permission. 

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF
THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * ******************************************************/
using Ookii.Dialogs.Wpf;


namespace BatchFindReplace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void browse_Click(object sender, RoutedEventArgs e)
        {
            // Create VistaFolderBrowserDialog which allows you to select a folder with better graphic
            //implementation
            VistaFolderBrowserDialog dlg = new VistaFolderBrowserDialog();

            // Display VistaFolderBrowserDialog by calling ShowDialog method 
            var result = dlg.ShowDialog();

            // Get the selected folder name and display in a TextBox 
            if (result == true)
            {
                // Open folder 
                string foldername = dlg.SelectedPath;
                pathBox.Text = foldername;
            }
        }

        //this just gives a boolean value to the check boxes
        private void numberFiles_Check(object sender, RoutedEventArgs e)
        {
            numberCheckBox.IsChecked = true;
        }

        private void numberFiles_Unchecked(object sender, RoutedEventArgs e)
        {
            numberCheckBox.IsChecked = false;
        }

        private void removeNumberFiles_Uncheck(object sender, RoutedEventArgs e)
        {
            removeNumberCheckBox.IsChecked = false;
        }

        private void removeNumberFiles_Checked(object sender, RoutedEventArgs e)
        {
            removeNumberCheckBox.IsChecked = true;
        }

        private void processButton_Click(object sender, RoutedEventArgs e)
        {
            //Number first then do the find replace.  That will ensure that things are kept in the same order of the original list
            if (numberCheckBox.IsChecked.ToString() == "True" && removeNumberCheckBox.IsChecked.ToString() == "False")
            {
                FileNumbering.AddNumbers();
            }
            else if (numberCheckBox.IsChecked.ToString() == "False" && removeNumberCheckBox.IsChecked.ToString() == "True")
            {
                FileNumbering.RemoveNumbers();
            }

            //This does checks to ensure that a destination folder is selected and that there is some text to find
            if ((pathBox.Text != "" || pathBox.Text != @"ex:  c:\users\default\documents\") && findTextBox.Text != "")
            {

                int charAfter, charBefore;
                // converts the characters before and characters after boxes in the form to integers to be used
                //in computing index positions in the follow on method.  if it's left blank then it just sets the 
                //value to 0.  otherwise it's the integer value of what was typed in
                if (charactersAfterTextBox.Text == "")
                {
                    charAfter = 0;
                }
                else
                {
                    charAfter = Int32.Parse(charactersAfterTextBox.Text);
                }
                if (charactersBeforeTextBox.Text == "")
                {
                    charBefore = 0;
                }
                else
                {
                    charBefore = Int32.Parse(charactersBeforeTextBox.Text);
                }

                //this is a call to actually do the find and replace given all the pertinent parameters
                SearchClass.FindReplace(pathBox.Text, findTextBox.Text, replaceTextBox.Text, charBefore, charAfter);

            }
            else
            {
                MessageBox.Show("You have to select a folder or the program will crash");
            }


        }
    }
}
