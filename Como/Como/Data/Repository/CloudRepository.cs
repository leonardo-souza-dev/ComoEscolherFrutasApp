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
    public class CloudRepository : IRepository, ISujeito, IObservador
    {
        private List<IObservador> Observadores = new List<IObservador>();

        public CloudRepository()
        {

        }

        public async Task<List<Dica>> ObterDicas()
        {
            var dicas = await Resposta<List<Dica>>(null, "obterdicas");

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

        private static async Task<T> Resposta<T>(object conteudo, string metodo, bool ehDownload = false)
        {
            var httpClient = new HttpClient();
            var uri = App.Config.ObterUrlBaseWebApi(metodo);

            if (conteudo != null)
            {
                var retorno = await new ClienteHttp().PostAsync<T>(uri, conteudo);

                return retorno;
            }
            else
            {
                var retorno = await new ClienteHttp().GetAsync<T>(uri);

                return retorno;
            }
        }
    }
}
