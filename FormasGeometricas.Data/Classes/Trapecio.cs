using FormasGeometricas.Globalization;

namespace FormasGeometricas.Data.Classes
{
    public class Trapecio : Forma
    {
        #region Properties
        public decimal Base1 { get; set; }
        public decimal Base2 { get; set; }
        public decimal Base3 { get; set; }
        public decimal Base4 { get; set; }
        public decimal Altura { get; set; }
        #endregion

        private readonly ILocalization Localization;

        public Trapecio() { }

        public Trapecio(ILocalization localization)
        {
            this.Localization = localization;
        }

        public override decimal CalcularArea()
        {
            return ((Base1 + Base2) / 2) * Altura;
        }

        public override decimal CalcularPerimetro()
        {
            return (Base1 + Base2 + Base3 + Base4);
        }

        public override string TraducirForma()
        {
            return Localization.LocalizeString("trapecio");
        }

        public override string TraducirFormaPlural()
        {
            return Localization.LocalizeString("trapecios");
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
