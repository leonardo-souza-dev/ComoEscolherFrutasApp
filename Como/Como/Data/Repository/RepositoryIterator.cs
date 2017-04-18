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
        IRepository[]
        itens;

        int posicao = 0;

        public RepositoryIterator(IRepository[] repos)
        {
            itens = repos;
        }

        public void resetPosition()
        {
            posicao = 0;
        }

        public object Next()
        {
            IRepository iRepository = itens[posicao];
            posicao++;
            return iRepository;
        }

        public bool HasNext()
        {
            if (posicao >= itens.Length || itens[posicao] == null)
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
