using System.Runtime.Serialization;

namespace Como.Model
{
    [DataContract]
    public class RespostaUsuario
    {
        [DataMember]
        internal int usuarioId;

        [DataMember]
        internal string email;

        [DataMember]
        internal string nomeArquivoAvatar;

        [DataMember]
        internal string nomeUsuario;
    }
}
