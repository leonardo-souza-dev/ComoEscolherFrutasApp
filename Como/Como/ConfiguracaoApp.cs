using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Como
{
    public class Helper
    {
        bool DebugarAndroid = false;
        public bool UsarCloud { get { return false; } }

        public string ObterUrlImagem(string nomeArquivo)
        {
            //return this.ObterUrlBaseWebApi() + "fruta?na=" + nomeArquivo;
            return "https://upload.wikimedia.org/wikipedia/commons/thumb/3/35/600px_HEX-008A79_rectangle_on_HEX-FEFCF0.svg/" + nomeArquivo;//TEMP
        }

        public string ObterCaminhoPadraoDevice(string arquivo)
        {
            var caminho = DependencyService.Get<IFileHelper>().GetLocalFilePath(arquivo);

            return caminho;
        }

        public string ObterUrlBaseWebApi(string metodo = null)
        {

            string enderecoBase = string.Empty;

            if (UsarCloud)
                enderecoBase = "https://comowebapi.herokuapp.com/";
            else
            {
                enderecoBase += "http://";
                if (DebugarAndroid)
                    enderecoBase += "10.0.2.2";
                else
                    enderecoBase += "localhost";
                enderecoBase += ":3000/";
            }

            enderecoBase += string.IsNullOrEmpty(metodo) ? "api/" : "api/" + metodo;

            return enderecoBase;
        }
    }
}
