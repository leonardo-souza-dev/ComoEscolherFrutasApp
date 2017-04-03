using Como.Model;
using Como.Data;
using Como.ViewModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Como.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrutaView : ContentPage
    {
        private Stream Stream = null;
        private MediaFile File;

        public ObservableCollection<Fruta> posts { get; set; }

        public string Arquivo = string.Empty;

        public FrutaView()
        {
            InitializeComponent();

            this.Title = "fruta";
            CrossMedia.Current.Initialize();

            //this.BindingContext = App.FrutasVM.Fruta;
        }
        


        protected async void OnImageTapped(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            File = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions()
            {
                CompressionQuality = 50
            });

            if (File == null)
                return;

            FotoImage.Source = ImageSource.FromStream(ObterStream);
        }
        private Stream ObterStream()
        {
            Stream stream = File.GetStream();
            Stream = File.GetStream();
            File.Dispose();

            return stream;
        }
    }
}
