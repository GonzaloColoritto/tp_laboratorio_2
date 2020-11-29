using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;

namespace TestsUnitarios
{
    [TestClass]
    public class TestCollection
    {
        [TestMethod]
        public void ListaAlumnosEnJornadaEsInstanciada()
        {
            
            Jornada jornada =
                new Jornada(Universidad.EClases.SPD, new Profesor());

            
            jornada.Alumnos.Add(new Alumno());

            
            Assert.IsNotNull(jornada.Alumnos);
        }

    }
}
