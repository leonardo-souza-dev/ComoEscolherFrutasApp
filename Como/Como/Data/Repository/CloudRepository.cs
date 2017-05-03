using System.Net.Http;
using Como.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Reflection;
using System.Threading.Tasks;

namespace Como.Data
{
    public class CloudRepository
    {
        #region ObservablePattern

        public void Atualizar(ISujeito s, string param, object valor)
        {
            if (s != this)
            {
                if (param.Equals(""))
                {
                    if (valor != null)
                    {
                    }
                }
            }
            throw new NotImplementedException();
        }

        private List<IObservador> Observadores = new List<IObservador>();

        public void NotificarObservadores(string param, object valor)
        {
            foreach (IObservador observador in Observadores)
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

        #endregion

        public async Task<List<Dica>> ObterDicas()
        {
            var dicas = await Resposta<List<Dica>>(null, "obterdicas");

            foreach (var dica in dicas)
            {
                DependencyService.Get<IPicture>().SavePictureToDisk(dica.NomeArquivo, dica.Imagem.Data);
                NotificarObservadores("OBTERDICAS", dica);
            }            

            return dicas;
        }

        private async Task<T> Resposta<T>(object conteudo, string metodo, bool ehDownload = false)
        {
            var uri = App.Helper.ObterUrlBaseWebApi(metodo);

            if (conteudo != null)
            {
                var cliente = new ClienteHttp();
                var res = await cliente.PostAsync<T>(uri, conteudo);

                return res;
            }
            else
            {
                var cliente = new ClienteHttp();
                var res = await cliente.GetAsync<T>(uri);

                return res;
            }
        }
    }
}
