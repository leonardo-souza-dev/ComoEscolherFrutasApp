using System.Runtime.Serialization;

namespace Como.Model
{
    [DataContract]
    public class RespostaEsqueciSenha
    {
        [DataMember]
        internal string mensagem;

        [DataMember]
        internal bool sucesso;
    }
}
