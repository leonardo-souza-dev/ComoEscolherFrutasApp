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
            var dicas = await App.Database.GetItemsAsync();

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

        public void Atualizar(ISujeito s, string p, object v)
        {
            throw new NotImplementedException();
        }
    }
}
