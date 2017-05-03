using Como.Data;
using Como.Model;
using PCLStorage;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;

namespace Como.ViewModel
{
    public class DicaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Dica> Dicas { get { return _dicas; } set { _dicas = value; OnPropertyChanged("Dicas"); } }
        private ObservableCollection<Dica> _dicas = new ObservableCollection<Dica>();

        public RepositoryIterator RepositoryIterator;
        public DicaViewModel()
        {

        }
        public DicaViewModel(RepositoryIterator repositoryIterator)
        {
            RepositoryIterator = repositoryIterator;
        }

        public async void ObterDicas()
        {
            DeviceRepository deviceRepository = new DeviceRepository();
            var dicas = deviceRepository.ObterDicas();

            for (int index = 0; index < dicas.Count; index++)
            {
                var dica = dicas[index];

                if (index + 1 > Dicas.Count || Dicas[index].Equals(dica))
                {
                    Image image = new Image();
                    IFolder rootFolder = FileSystem.Current.LocalStorage;
                    IFile file = rootFolder.GetFileAsync(dica.NomeArquivo).Result;
                    Stream s = file.OpenAsync(FileAccess.Read).Result;

                    dica.ImagemBinding.Source = ImageSource.FromStream(() => s);

                    Dicas.Insert(index, dica);
                }
            }

            CloudRepository cloudRepository = new CloudRepository();
            var dicasCloud = await cloudRepository.ObterDicas();

            if (dicasCloud != null && dicasCloud.Count > 0)
            {
                for (int index = 0; index < dicas.Count; index++)
                {
                    var dicaCloud = dicas[index];

                    Image image = new Image();
                    IFolder rootFolder = FileSystem.Current.LocalStorage;
                    IFile file = rootFolder.GetFileAsync(dicaCloud.NomeArquivo).Result;
                    Stream s = file.OpenAsync(FileAccess.Read).Result;

                    dicaCloud.ImagemBinding.Source = ImageSource.FromStream(() => s);

                    for(int i = 0; i < Dicas.Count; i++)
                    {
                        if (Dicas[i].ID == dicaCloud.ID)
                        {
                            Dicas[i] = dicaCloud;
                        }
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
    }
}
