using FALL.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FALL
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void PlainText_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlainTextPage());
        }

        private async void LocalFile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocalFilePage());
        }

        private async void AzureBlobFilePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AzureBlobFilePage());
        }
    }
}
