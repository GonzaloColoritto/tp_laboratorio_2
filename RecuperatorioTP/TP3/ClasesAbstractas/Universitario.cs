using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }


        protected virtual string MostrarDatos()
        {
            return base.ToString() + $"NÚMERO LEGAJO: {legajo}\n";
        }

        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario u1, Universitario u2)
        {
            bool retorno = false;

            if (u1.legajo == u2.legajo || u1.DNI == u2.DNI)
            {
                retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }

    }
}
