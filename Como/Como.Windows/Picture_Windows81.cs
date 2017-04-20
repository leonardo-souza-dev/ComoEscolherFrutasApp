using Como.Data;
using Como.Windows;
using System;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Picture_Windows81))]
namespace Como.Windows
{
    public class Picture_Windows81 : IPicture
    {
        public async void SavePictureToDisk(string filename, byte[] imageData)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteBytesAsync(sampleFile, imageData);
        }
    }
}
