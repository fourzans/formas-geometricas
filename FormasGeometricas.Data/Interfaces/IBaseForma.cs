using FormasGeometricas.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormasGeometricas.Data.Interfaces
{
    public interface IBaseForma<T> where T : Forma
    {
        decimal Lado { get; set; }
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string TraducirForma();
        string ObtenerLinea();
        int GetListCount();
    }
}
