using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FormasGeometricas.Data.Classes;
using FormasGeometricas.Globalization;
using NUnit.Framework;
using System.Collections.Generic;

namespace FormasGeometricas.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        private WindsorContainer Container;

        [SetUp]
        public void SetUp()
        {
            Container = new WindsorContainer();
            Container.Register(Component.For(typeof(ILocalization)).ImplementedBy<Localization>());
        }

        [TearDown]
        public void TearDownw()
        {
            Container.Dispose();
        }

        [TestCase]
        public void TestResumenListaVacia()
        {
            IEnumerable<Forma> formas = new List<FormaGroup<Cuadrado>>();
            EnhacedFormaGeometrica.Localization = Container.Resolve<ILocalization>();
            EnhacedFormaGeometrica.Localization.SetCurrentCulture("es-AR");

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                EnhacedFormaGeometrica.Imprimir(formas));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            IEnumerable<Forma> formas = new List<FormaGroup<Cuadrado>>();
            EnhacedFormaGeometrica.Localization = Container.Resolve<ILocalization>();

            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                EnhacedFormaGeometrica.Imprimir(formas));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnRuso()
        {
            IEnumerable<Forma> formas = new List<FormaGroup<Cuadrado>>();
            EnhacedFormaGeometrica.Localization = Container.Resolve<ILocalization>();
            EnhacedFormaGeometrica.Localization.SetCurrentCulture("ru-RU");

            Assert.AreEqual("<h1>Список фигур пуст!</h1>",
                EnhacedFormaGeometrica.Imprimir(formas));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            EnhacedFormaGeometrica.Localization = Container.Resolve<ILocalization>();
            EnhacedFormaGeometrica.Localization.SetCurrentCulture("es-AR");

            IEnumerable<Forma> formas = new List<Cuadrado> { new Cuadrado(EnhacedFormaGeometrica.Localization) { Lado = 5 } };

            var resumen = EnhacedFormaGeometrica.Imprimir(formas);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 forma Perimetro 20 Area 25", resumen);
        }


        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            EnhacedFormaGeometrica.Localization = Container.Resolve<ILocalization>();

            var FormaGroup = new FormaGroup<Forma>(EnhacedFormaGeometrica.Localization);
            FormaGroup.Add(new Cuadrado(EnhacedFormaGeometrica.Localization) { Lado = 5 });
            FormaGroup.Add(new Cuadrado(EnhacedFormaGeometrica.Localization) { Lado = 1 });
            FormaGroup.Add(new Cuadrado(EnhacedFormaGeometrica.Localization) { Lado = 3 });

            var resumen = EnhacedFormaGeometrica.Imprimir(new List<FormaGroup<Forma>> { FormaGroup });

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecio()
        {
            EnhacedFormaGeometrica.Localization = Container.Resolve<ILocalization>();

            IEnumerable<Forma> formas = new List<Trapecio> { new Trapecio(EnhacedFormaGeometrica.Localization) { Base1 = 5, Base2 = 6, Base3 = 4, Base4 = 3, Altura = 8 } };

            var resumen = EnhacedFormaGeometrica.Imprimir(formas);

            Assert.AreEqual("<h1>Shapes report</h1>1 Trapezium | Area 44 | Perimeter 18 <br/>TOTAL:<br/>1 shape Perimeter 18 Area 44", resumen);
        }

        [TestCase]
        public void TestResumenListaConUnTrapecioUnCuadrado()
        {
            EnhacedFormaGeometrica.Localization = Container.Resolve<ILocalization>();

            IEnumerable<Forma> formas = new List<Forma>
            {
                new Trapecio(EnhacedFormaGeometrica.Localization) { Base1 = 5, Base2 = 6, Base3 = 4, Base4 = 3, Altura = 8 },
                new Cuadrado(EnhacedFormaGeometrica.Localization) { Lado = 5 }
            };

            var resumen = EnhacedFormaGeometrica.Imprimir(formas);

            Assert.AreEqual("<h1>Shapes report</h1>1 Trapezium | Area 44 | Perimeter 18 <br/>1 Square | Area 25 | Perimeter 20 <br/>TOTAL:<br/>2 shapes Perimeter 38 Area 69", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            EnhacedFormaGeometrica.Localization = Container.Resolve<ILocalization>();

            var FormaGroupCuadrado = new FormaGroup<Forma>(EnhacedFormaGeometrica.Localization);
            FormaGroupCuadrado.Add(new Cuadrado(EnhacedFormaGeometrica.Localization) { Lado = 5 });
            FormaGroupCuadrado.Add(new Cuadrado(EnhacedFormaGeometrica.Localization) { Lado = 2});

            var FormaGroupCirculo = new FormaGroup<Forma>(EnhacedFormaGeometrica.Localization);
            FormaGroupCirculo.Add(new Circulo(EnhacedFormaGeometrica.Localization) { Lado = 3 });
            FormaGroupCirculo.Add(new Circulo(EnhacedFormaGeometrica.Localization) { Lado = 2.75m });

            var FormaGroupTrianguloEquilatero= new FormaGroup<Forma>(EnhacedFormaGeometrica.Localization);
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(EnhacedFormaGeometrica.Localization) { Lado = 4 });
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(EnhacedFormaGeometrica.Localization) { Lado = 9 });
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(EnhacedFormaGeometrica.Localization) { Lado = 4.2m });

            var resumen = EnhacedFormaGeometrica.Imprimir(new List<FormaGroup<Forma>> { FormaGroupCuadrado, FormaGroupCirculo, FormaGroupTrianguloEquilatero });

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            EnhacedFormaGeometrica.Localization = Container.Resolve<ILocalization>();
            EnhacedFormaGeometrica.Localization.SetCurrentCulture("es-AR");

            var FormaGroupCuadrado = new FormaGroup<Forma>(EnhacedFormaGeometrica.Localization);
            FormaGroupCuadrado.Add(new Cuadrado(EnhacedFormaGeometrica.Localization) { Lado = 5 });
            FormaGroupCuadrado.Add(new Cuadrado(EnhacedFormaGeometrica.Localization) { Lado = 2 });

            var FormaGroupCirculo = new FormaGroup<Forma>(EnhacedFormaGeometrica.Localization);
            FormaGroupCirculo.Add(new Circulo(EnhacedFormaGeometrica.Localization) { Lado = 3 });
            FormaGroupCirculo.Add(new Circulo(EnhacedFormaGeometrica.Localization) { Lado = 2.75m });

            var FormaGroupTrianguloEquilatero = new FormaGroup<Forma>(EnhacedFormaGeometrica.Localization);
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(EnhacedFormaGeometrica.Localization) { Lado = 4 });
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(EnhacedFormaGeometrica.Localization) { Lado = 9 });
            FormaGroupTrianguloEquilatero.Add(new TrianguloEquilatero(EnhacedFormaGeometrica.Localization) { Lado = 4.2m });

            var resumen = EnhacedFormaGeometrica.Imprimir(new List<FormaGroup<Forma>> { FormaGroupCuadrado, FormaGroupCirculo, FormaGroupTrianguloEquilatero });

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13.01 | Perimetro 18.06 <br/>3 Triángulos | Area 49.64 | Perimetro 51.6 <br/>TOTAL:<br/>7 formas Perimetro 97.66 Area 91.65",
                resumen);
        }
    }
}
