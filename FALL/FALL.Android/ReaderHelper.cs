using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FALL.Droid
{
    public static class ReaderHelper
    {
        public const string ACCOUNT_NAME = "<BLOB_STORAGE_NAME>";
        public const string ACCOUNT_ACCESS_KEY = "<BLOB_ACCESS_KEY>";
        public const string ACCOUNT_URL = "<STORAGE_ACCOUNT_URL>";
        public const string CONTAINER_NAME = "<BLOB_CONTAINER_NAME>";
        public const string BLOB_NAME = "UploadAzureBlob.txt";

        static string storageConnectionString = "DefaultEndpointsProtocol=https;"
                                        + "AccountName=<ACCOUNT_NAME>"
                                        + ";AccountKey=<ACCOUNT_ACCESS_KEY>"
                                        + ";EndpointSuffix=core.windows.net";

        public static string FileText { get; set; }

        public static async Task<string> ReadFileFromAzureBlob()
        {
            string text = "";
            CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient serviceClient = account.CreateCloudBlobClient();

            var container = serviceClient.GetContainerReference(CONTAINER_NAME);
            CloudBlob blob = container.GetBlobReference(BLOB_NAME);
            using (Stream stream = await blob.OpenReadAsync())
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    text = reader.ReadToEnd();
                }
            }

            return text;
        }
    }
}