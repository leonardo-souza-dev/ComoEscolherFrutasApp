using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Como.Model;
using System;
using System.Collections.Generic;

namespace Como.Data
{
    public class DeviceRepository : IRepository, ISujeito, IObservador
    {
        private List<IObservador> Observadores = new List<IObservador>();

        public DeviceRepository()
        {

        }

        public List<Dica> ObterDicas()
        {
            var dicas = App.Database.GetItemsSync();

            return dicas;
        }

        public void NotificarObservadores(string p, object v)
        {
            throw new NotImplementedException();
        }


        public void RegistrarObservador(IObservador o)
        {
            Observadores.Add(o);
        }

        public void RemoverObservador(IObservador o)
        {
            Observadores.Remove(o);
        }

        public async void Atualizar(ISujeito s, string param, object valor)
        {
            if (s != this)
            {

                if (param.Equals("dica")) { }
                {
                    if (valor != null)
                    {
                        Dica dica = (Dica)valor as Dica;

                        await App.Database.UpsertItemAsync(dica);
                    }
                }                
            }
        }
    }
}
