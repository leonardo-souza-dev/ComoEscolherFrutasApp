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
    public class DicaViewModel2 : INotifyPropertyChanged
    {
        public ObservableCollection<Dica> Dicas { get { return _dicas; } set { _dicas = value; OnPropertyChanged("Dicas"); } }
        private ObservableCollection<Dica> _dicas = new ObservableCollection<Dica>();

        public RepositoryIterator RepositoryIterator;

        public DicaViewModel2(RepositoryIterator repositoryIterator)
        {
            RepositoryIterator = repositoryIterator;
        }

        public void ObterDicas()
        {
            var lista = new List<Dica>();
            bool encontrou = false;

            while (!encontrou && RepositoryIterator.HasNext())
            {
                IRepository iRepository = (IRepository)RepositoryIterator.Next();
                lista = iRepository.ObterDicas();
                if (lista != null && lista.Count > 0) //TODO: Implementar sincronizacao do dado via hash
                {
                    encontrou = true;
                }
            }
            RepositoryIterator.resetPosition();

            for (int index = 0; index < lista.Count; index++)
            {
                var dica = lista[index];

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
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
    }
}
