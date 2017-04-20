using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Como.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace Como.Data
{
    public static class DicaRepositorio
    {
        public static async Task<List<Dica>> ObterDicas()
        {
            var frutas = await Resposta<List<Dica>>(null, "obterdicas");

            Objetos(frutas);
            Debug.WriteLine("<DEBUG ObterFrutas>");
            foreach (var item in frutas)
            {
                Debug.WriteLine("fruta.ID: " + item.ID);
                //Debug.WriteLine("fruta.ImagemUrl: " + item.UrlImagem);
                Debug.WriteLine("fruta.Dica: "+ item.Descricao);
            }
            Debug.WriteLine("</DEBUG ObterFrutas>");
            return frutas;
        }

        private static async Task<T> Resposta<T>(object conteudo, string metodo, bool ehDownload = false)
        {
            var httpClient = new HttpClient();
            var uri = App.Helper.ObterUrlBaseWebApi(metodo);

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

        private static T ObterObjeto<T>(Stream stream)
        {
            var ser = new DataContractJsonSerializer(typeof(T));
            stream.Position = 0;
            var resposta = (T)ser.ReadObject(stream);

            return resposta;

        }

        public static object Objetos(object objectos)
        {
            return objectos;
        }

        private static Dica Convert(System.IO.Stream stream)
        {
            var ser3 = new DataContractJsonSerializer(typeof(Dica));
            stream.Position = 0;
            Dica resposta3 = (Dica)ser3.ReadObject(stream);
            Debug.WriteLine("PostModel");
            Debug.WriteLine(resposta3.ID);
            Debug.WriteLine(resposta3.Descricao);
            return resposta3;
        }
    }
}
