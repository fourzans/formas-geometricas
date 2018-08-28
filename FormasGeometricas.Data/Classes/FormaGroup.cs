using FormasGeometricas.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace FormasGeometricas.Data.Classes
{
    public class FormaGroup<T> : Forma where T : Forma
    {
        private List<T> FormaGeometricaList { get; set; } = new List<T>();

        private readonly ILocalization Localization;

        public FormaGroup(ILocalization localization)
        {
            this.Localization = localization;
        }

        public FormaGroup() { }

        public FormaGroup(List<T> list)
        {
            this.FormaGeometricaList = list;
        }

        public override decimal CalcularArea()
        {
            decimal area = 0;

            foreach(T forma in FormaGeometricaList) 
                area += forma.CalcularArea();
            
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            decimal perimetro = 0;

            foreach (T forma in FormaGeometricaList)
                perimetro += forma.CalcularPerimetro();

            return perimetro;
        }

        public override string TraducirForma()
        {
            if (FormaGeometricaList.Any() && FormaGeometricaList.Count > 0)
                return FormaGeometricaList.FirstOrDefault().TraducirFormaPlural();

            return string.Empty;
        }

        public override string ObtenerLinea()
        {
            if(FormaGeometricaList.Any())
            {
                return $"{FormaGeometricaList.Count} {TraducirForma()} | {Localization.LocalizeString("area")} {CalcularArea():#.##} | {Localization.LocalizeString("perimetro")} {CalcularPerimetro():#.##} <br/>";
            }

            return string.Empty;
        }

        public override int GetListCount()
        {
            return FormaGeometricaList.Count;
        }

        public override void Add(Forma forma)
        {
            this.FormaGeometricaList.Add((T)forma);
        }

        public override void Remove(Forma forma)
        {
            this.FormaGeometricaList.Remove((T)forma);
        }
    }
}
