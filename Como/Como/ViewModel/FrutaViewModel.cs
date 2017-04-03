using Como.Data;
using Como.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Como.ViewModel
{
    public class FrutaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Fruta> Frutas { get { return _frutas; } set { _frutas = value; OnPropertyChanged("Frutas"); } }
        private ObservableCollection<Fruta> _frutas = new ObservableCollection<Fruta>();


        public async void ObterFrutas()
        {
            var listaFrutas = new List<Fruta>();

            listaFrutas = await FrutaRepositorio.ObterFrutas();

            for (int index = 0; index < listaFrutas.Count; index++)
            {
                var fruta = listaFrutas[index];

                if (index + 1 > Frutas.Count || Frutas[index].Equals(fruta))
                {
                    Frutas.Insert(index, fruta);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
    }
}
