using FormasGeometricas.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormasGeometricas.Data.Classes
{
    public abstract class Forma : IForma
    {
        public decimal Lado { get; set; }

        public virtual decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public virtual decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }

        public virtual string TraducirForma()
        {
            throw new NotImplementedException();
        }

        public virtual string TraducirFormaPlural()
        {
            throw new NotImplementedException();
        }

        public virtual string ObtenerLinea()
        {
            throw new NotImplementedException();
        }

        public virtual int GetListCount()
        {
            throw new NotImplementedException();
        }

        public abstract void Add(Forma forma);
        public abstract void Remove(Forma forma);
    }
}

