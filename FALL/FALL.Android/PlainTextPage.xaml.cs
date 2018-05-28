using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FALL.Droid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlainTextPage : ContentPage
    {
        string textToRead = string.Empty;

        public PlainTextPage()
        {
            InitializeComponent();
        }

        public PlainTextPage(string text)
        {
            InitializeComponent();
            lblTitle.Text = "Text from file...";
            textToRead = text;
            TextToRead.Text = text;
        }

        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<ITextToSpeech>().Speak(textToRead);
        }

        private void Editor_Completed(object sender, EventArgs e)
        {
            textToRead = ((Editor)sender).Text;
        }
    }
}