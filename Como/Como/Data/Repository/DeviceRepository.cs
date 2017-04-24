using Como.Model;
using System;
using System.Collections.Generic;

namespace Como.Data
{
    public class DeviceRepository : IRepository, ISujeito, IObservador
    {
        #region ObservablePattern

        public void Atualizar(ISujeito s, string param, object valor)
        {
            if (s != this)
            {
                if (param.Equals("OBTERDICAS"))
                {
                    if (valor != null)
                    {
                        Dica dica = (Dica)valor as Dica;
                        
                        App.Database.UpsertDicaSync(dica);
                    }                    
                }
            }
        }

        private List<IObservador> Observadores = new List<IObservador>();

        public void NotificarObservadores(string p, object v)
        {
            throw new NotImplementedException();
        }

        public void RegistrarObservador(IObservador o)
        {
            Observadores.Add(o);
        }

        public void RemoverObservador(IObservador o)
        {
            Observadores.Remove(o);
        }

        #endregion

        public List<Dica> ObterDicas()
        {
            var dicas = App.Database.ObterDicasSync();

            return dicas;
        }
    }
}
