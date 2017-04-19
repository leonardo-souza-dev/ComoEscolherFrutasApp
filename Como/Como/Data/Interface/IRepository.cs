using Como.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Como.Data
{
    public interface IRepository
    {
        List<Dica> ObterDicas();
    }   
}
