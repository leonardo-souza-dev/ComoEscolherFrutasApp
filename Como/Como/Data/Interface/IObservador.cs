using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Como.Data
{
    public interface IObservador
    {
        void Atualizar(ISujeito s, string p, object v);
    }
}
