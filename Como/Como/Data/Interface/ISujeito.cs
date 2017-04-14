using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Como.Data
{
    public interface ISujeito
    {
        void RegistrarObservador(IObservador o);

        void RemoverObservador(IObservador o);

        void NotificarObservadores(string p, object v);
    }
}
