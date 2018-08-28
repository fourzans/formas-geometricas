using FormasGeometricas.Globalization;

namespace FormasGeometricas.Data.Classes
{
    public class Cuadrado : Forma
    {
        private readonly ILocalization Localization;

        public Cuadrado() { }

        public Cuadrado(ILocalization localization)
        {
            this.Localization = localization;
        }
                
        public override decimal CalcularArea()
        {
            return Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 4;
        }

        public override string TraducirForma()
        {
            return Localization.LocalizeString("cuadrado");
        }

        public override string TraducirFormaPlural()
        {
            return Localization.LocalizeString("cuadrados");
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
            throw new System.NotImplementedException("Operation not permitted since this is a leaf node");
        }

        public override void Remove(Forma forma)
        {
            throw new System.NotImplementedException("Operation not permitted since this is a leaf node");
        }
    }
}
