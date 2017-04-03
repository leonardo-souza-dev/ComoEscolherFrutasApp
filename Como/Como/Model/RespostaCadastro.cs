using System.Runtime.Serialization;

namespace Como.Model
{
    [DataContract]
    public class RespostaCadastro
    {
        [DataMember]
        internal bool sucesso;

        [DataMember]
        internal string mensagem;

        [DataMember]
        internal RespostaUsuario usuario;
    }
}
