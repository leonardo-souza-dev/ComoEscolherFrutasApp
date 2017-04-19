using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Como.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Como.Data
{
    public class CloudRepository : IRepository, ISujeito, IObservador
    {
        private List<IObservador> Observadores = new List<IObservador>();

        public CloudRepository()
        {

        }

        public List<Dica> ObterDicas()
        {
            var dicas = Resposta<List<Dica>>(null, "obterdicas");

            foreach (var dica in dicas)
            {
                DependencyService.Get<IPicture>().SavePictureToDisk(dica.ID.ToString(), dica.Imagem.Data);
                NotificarObservadores("dica", dica);
            }
            

            return dicas;
        }

        public void NotificarObservadores(string param, object valor)
        {
            foreach(IObservador observador in Observadores)
            {
                observador.Atualizar(this, param, valor);
            }
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

        private T Resposta<T>(object conteudo, string metodo, bool ehDownload = false)
        {
            var httpClient = new HttpClient();
            var uri = App.Config.ObterUrlBaseWebApi(metodo);

            if (conteudo != null)
            {
                var retorno = new ClienteHttp().PostSync<T>(uri, conteudo);

                return retorno;
            }
            else
            {
                var retorno = new ClienteHttp().GetSync<T>(uri);

                return retorno;
            }
        }
    }
}
