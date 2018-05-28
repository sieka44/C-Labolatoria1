using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class DictionaryForm : Form
    {
        TextChecker textChecker = new TextChecker();
        public DictionaryForm()
        {
            InitializeComponent();
        }

        private async void verifyButton_click(object sender, EventArgs e)
        {
            progressBar.Maximum = 100;
            progressBar.Step = 1;

            var progress = new Progress<int>(v =>
           {
               progressBar.Value = v;
           });
           await Task.Run(() => ParseText(progress));
        }

        private void ParseText(IProgress<int> progress)
        {
            String s = inputTextBox.Text.ToLower();
            String[] text = Regex.Replace(s, @"[^a-z ]+", String.Empty).Split(' ');
            List<String> listOfErrors = textChecker.CheckText(text, progress);


            //wypisanie

            errorTextBox.Invoke(new Action(delegate ()
            {
                errorTextBox.Text = String.Join(", ", listOfErrors);
            }));

            StringBuilder stringBuilder = new StringBuilder();
            var dictionary = textChecker.WordCount;
            foreach (var word in dictionary)
            {
                stringBuilder.Append(word.Key + " - " + word.Value + "\r\n");
            }
            errorTextBox.Invoke(new Action(delegate ()
            {
                countsTextBox.Text = stringBuilder.ToString();
            }));
            
        }

     

    }
}
