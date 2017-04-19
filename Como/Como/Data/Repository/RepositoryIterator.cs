using Newtonsoft.Json;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Como.Model;
using System;
using System.Collections.Generic;

namespace Como.Data
{
    public class RepositoryIterator : IITerador
    {
        IRepository[] Itens;
        int Posicao = 0;

        public RepositoryIterator(IRepository[] repos)
        {
            Itens = repos;
        }

        public void resetPosition()
        {
            Posicao = 0;
        }

        public object Next()
        {
            IRepository iRepository = Itens[Posicao];
            Posicao++;
            return iRepository;
        }

        public bool HasNext()
        {
            if (Posicao >= Itens.Length || Itens[Posicao] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
