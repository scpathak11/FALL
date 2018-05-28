using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FALL.Droid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AzureBlobFilePage : ContentPage
    {
        public AzureBlobFilePage()
        {
            InitizeText();
        }

        private async void InitizeText()
        {
            string text = await ReaderHelper.ReadFileFromAzureBlob();
            await Navigation.PushAsync(new PlainTextPage(text));
        }
    }
}