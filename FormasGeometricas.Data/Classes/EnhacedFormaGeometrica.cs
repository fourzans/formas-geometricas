/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using FormasGeometricas.Data.Interfaces;
using FormasGeometricas.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormasGeometricas.Data.Classes
{
    public class EnhacedFormaGeometrica
    {
        public static ILocalization Localization { get; set; }
        public EnhacedFormaGeometrica(ILocalization localization)
        {
            Localization = localization;
        }
        public static string Imprimir(IEnumerable<Forma> formasList)
        {
            var sb = new StringBuilder();

            if (!formasList.Any())
            {
                sb.Append(Localization.LocalizeString("listaVaciaFormas"));
            }
            else
            {
                int cantidadFormas = 0;
                decimal sumaArea = 0;
                decimal sumaPerimetro = 0;

                sb.Append(Localization.LocalizeString("reporteFormas"));

                foreach (var formas in formasList)
                {
                    sb.Append(formas.ObtenerLinea());
                    cantidadFormas += formas.GetListCount();
                    sumaArea += formas.CalcularArea();
                    sumaPerimetro += formas.CalcularPerimetro();
                }

                // FOOTER
                sb.Append(Localization.LocalizeString("total"));
                sb.Append(cantidadFormas + " " + Localization.LocalizeString(cantidadFormas > 1 ? "formas" : "forma") + " ");
                sb.Append(Localization.LocalizeString("perimetro") + " " + sumaPerimetro.ToString("#.##") + " ");
                sb.Append(Localization.LocalizeString("area") + " " + sumaArea.ToString("#.##"));
            }

            return sb.ToString();
        }
    }
}
