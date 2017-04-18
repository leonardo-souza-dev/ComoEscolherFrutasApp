using Como.Data;
using Como.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;

[assembly: Dependency(typeof(Picture_WinPhone))]
namespace Como.Windows
{
    public class Picture_WinPhone : IPicture
    {
        public async void SavePictureToDisk(string filename, byte[] imageData)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteBytesAsync(sampleFile, imageData);
        }
    }
}
