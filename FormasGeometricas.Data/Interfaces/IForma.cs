using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormasGeometricas.Data.Interfaces
{
    public interface IForma
    {
        decimal Lado { get; set; }
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string TraducirForma();
    }
}
