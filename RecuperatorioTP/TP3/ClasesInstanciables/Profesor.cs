using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {   
        private static Random random;
        private Queue<Universidad.EClases> clasesDelDia;
        

        static Profesor()
        {
            random = new Random();
        }

        public Profesor() { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) :
            base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }


        protected override string ParticiparEnClase()
        {
            return $"CLASES DEL DÍA:\n{GetClasesDelDia()}";
        }


        public override string ToString()
        {
            return MostrarDatos();
        }

        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + ParticiparEnClase();
        }

        private void _randomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
        }

        private string GetClasesDelDia()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Universidad.EClases clase in clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }
        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases claseAux in profesor.clasesDelDia)
            {
                if (claseAux == clase)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Profesor profesor, Universidad.EClases clase)
        {
            return !(profesor == clase);
        }
    }
}
