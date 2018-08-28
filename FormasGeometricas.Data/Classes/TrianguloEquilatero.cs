using FormasGeometricas.Globalization;
using System;

namespace FormasGeometricas.Data.Classes
{
    public class TrianguloEquilatero : Forma
    {
        private readonly ILocalization Localization;

        public TrianguloEquilatero() { }

        public TrianguloEquilatero(ILocalization localization)
        {
            this.Localization = localization;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 3;
        }

        public override string TraducirForma()
        {
            return Localization.LocalizeString("triangulo");
        }

        public override string TraducirFormaPlural()
        {
            return Localization.LocalizeString("triangulos");
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
