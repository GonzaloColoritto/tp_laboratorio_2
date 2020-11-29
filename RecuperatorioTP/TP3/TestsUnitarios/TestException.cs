using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesAbstractas;
using ClasesInstanciables;


namespace TestsUnitarios
{
    [TestClass]
    public class TestException
    {

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaException()
        {
            Alumno alumno1;
            alumno1 = new Alumno(6, "Gonzalito", "Colorittito", "99999555", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

        }


        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            Alumno alumno2;
            alumno2 = new Alumno(5, "Gonzalo", "Coloritto", "4281859126",ClasesAbstractas.Persona.ENacionalidad.Argentino,Universidad.EClases.Laboratorio);

        }
        

    }
}
