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
    public static class FrutaRepositorio
    {
        public static async Task<List<Fruta>> ObterFrutas()
        {
            var frutas = await Resposta<List<Fruta>>(null, "obterfrutas");

            Objetos(frutas);
            Debug.WriteLine("<DEBUG ObterFrutas>");
            foreach (var item in frutas)
            {
                Debug.WriteLine("fruta.ID: " + item.ID);
                Debug.WriteLine("fruta.ImagemUrl: " + item.UrlImagem);
                Debug.WriteLine("fruta.Dica: "+ item.Dica);
            }
            Debug.WriteLine("</DEBUG ObterFrutas>");
            return frutas;
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

        private static Fruta Convert(System.IO.Stream stream)
        {
            var ser3 = new DataContractJsonSerializer(typeof(Fruta));
            stream.Position = 0;
            Fruta resposta3 = (Fruta)ser3.ReadObject(stream);
            Debug.WriteLine("PostModel");
            Debug.WriteLine(resposta3.ID);
            Debug.WriteLine(resposta3.Dica);
            return resposta3;
        }
    }
}
