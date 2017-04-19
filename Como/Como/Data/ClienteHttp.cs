using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Como.Data
{
    public class ClienteHttp
    {
        public async Task<T> PostAsync<T>(string uri, object objeto)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(objeto);
            var contentPost = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, contentPost);
            var stream = await response.Content.ReadAsStreamAsync();
            var ser = new DataContractJsonSerializer(typeof(T));
            stream.Position = 0;

            T t = (T)ser.ReadObject(stream);

            return t;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            var stream = await response.Content.ReadAsStreamAsync();
            var ser = new DataContractJsonSerializer(typeof(T));
            stream.Position = 0;
            T t = (T)ser.ReadObject(stream);

            return t;
        }
        public T PostSync<T>(string uri, object objeto)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(objeto);
            var contentPost = new StringContent(json, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(uri, contentPost).Result;
            var stream = response.Content.ReadAsStreamAsync().Result;
            var ser = new DataContractJsonSerializer(typeof(T));
            stream.Position = 0;

            T t = (T)ser.ReadObject(stream);

            return t;
        }

        public T GetSync<T>(string uri)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(uri).Result;
            var stream = response.Content.ReadAsStreamAsync().Result;
            var ser = new DataContractJsonSerializer(typeof(T));
            stream.Position = 0;
            T t = (T)ser.ReadObject(stream);

            return t;
        }
    }
}
