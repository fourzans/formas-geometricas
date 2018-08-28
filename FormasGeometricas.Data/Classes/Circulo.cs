using FormasGeometricas.Globalization;
using System;

namespace FormasGeometricas.Data.Classes
{
    public class Circulo : Forma
    {
        private readonly ILocalization Localization;

        public Circulo() { }

        public Circulo(ILocalization localization)
        {
            this.Localization = localization;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (Lado / 2) * (Lado / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * Lado;
        }

        public override string TraducirForma()
        {
            return Localization.LocalizeString("circulo");
        }

        public override string TraducirFormaPlural()
        {
            return Localization.LocalizeString("circulos");
        }

        public override string ObtenerLinea()
        {
            return $"1 {TraducirForma()} | {Localization.LocalizeString("area")} {CalcularArea():#.##} | {Localization.LocalizeString("perimetro")} {CalcularPerimetro():#.##} <br/>";
        }

        public override int GetListCount()
        {
            return 1;
        }

        public override void Add(Forma forma)
        {
            throw new NotImplementedException("Operation not permitted since this is a leaf node");
        }

        public override void Remove(Forma forma)
        {
            throw new NotImplementedException("Operation not permitted since this is a leaf node");
        }
    }
}
