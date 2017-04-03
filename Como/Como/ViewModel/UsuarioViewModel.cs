using Como.Data;
using Como.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Como.ViewModel
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        public UsuarioViewModel() { }


        #region Propriedades

        public string TempEmail;
        public string TempNomeArquivoAvatar;
        public string TempNomeUsuario;

        public int Id { get; set; }
        public string Nome { get; set; }
        public object AvatarUrl { get; set; }
        public bool EditouAvatar { get; set; }

        private UsuarioModel usuario;
        public UsuarioModel Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        #endregion

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public async Task<UsuarioModel> Login(string email, string senha)
        {
            this.Usuario = await UsuarioRepository.Login(email, senha);

            return this.Usuario;
        }

        public async Task<bool> TemConexaoComInternet()
        {
            return await UsuarioRepository.TesteConexao();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); }
    }
}
