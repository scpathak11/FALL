using Plugin.FilePicker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FALL.Droid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalFilePage : ContentPage
    {
        public LocalFilePage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                lbl.Text = file.FileName;
                ReaderHelper.FileText = System.Text.Encoding.UTF8.GetString(file.DataArray);
                await Navigation.PushAsync(new PlainTextPage(ReaderHelper.FileText));
            }
        }
    }
}