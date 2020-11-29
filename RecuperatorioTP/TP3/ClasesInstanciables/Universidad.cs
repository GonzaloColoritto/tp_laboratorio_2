using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;


namespace ClasesInstanciables
{
    [Serializable]
    public class Universidad
    {
        public enum EClases
        {
            Programacion, 
            Laboratorio, 
            Legislacion, 
            SPD  
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornadas = new List<Jornada>();
            profesores = new List<Profesor>();
        }
        public List<Profesor> Instructores
        {
            get
            {
                return profesores;
            }
            set
            {
                profesores = value;
            }
        }
        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
                alumnos = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return jornadas;
            }
            set
            {
                jornadas = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }
            set
            {
                jornadas[i] = value;
            }
        }
        public static Universidad Leer()
        {
            Universidad datosALeer = null;
            Xml<Universidad> serializadorHelper = new Xml<Universidad>();

            try
            {
                serializadorHelper.Leer(GetArchivo(), out datosALeer);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return datosALeer; ;
        }
        public static bool Guardar(Universidad uni)
        {
            
            Xml<Universidad> serializadorHelper = new Xml<Universidad>();
            bool retorno = false;
            try
            {
                retorno = serializadorHelper.Guardar(GetArchivo(), uni);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            return retorno;
        }
        private string MostrarDatos(Universidad universidad)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Jornada jornada in universidad.jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }
        private static string GetArchivo()
        {
            return AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
        }

        public static bool operator ==(Universidad universidad, Alumno alumnoAux)
        {
            bool retorno = false;

            foreach (Alumno alumno in universidad.alumnos)
            {
                if (alumno == alumnoAux)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return !(universidad == alumno);
        }
        public static bool operator ==(Universidad universidad, Profesor profesorAux)
        {
            bool retorno = false;

            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor == profesorAux)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return !(universidad == profesor);
        }
        public static Profesor operator ==(Universidad universidad, EClases clase)
        {
            Profesor profesor = null;

            foreach (Profesor profesorAux in universidad.profesores)
            {
                if (profesorAux == clase)
                {
                    profesor = profesorAux;
                    break;
                }
            }

            if (profesor == null)
            {
                throw new SinProfesorException("No hay profesor para la clase");
            }

            return profesor;
        }

        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            Profesor profesor = null;

            foreach (Profesor profesorAux in universidad.profesores)
            {
                if (profesorAux != clase)
                {
                    profesor = profesorAux;
                    break;
                }
            }

            return profesor;
        }

        public static Universidad operator +(Universidad universidad, EClases clase)
        {
            Universidad universidadAux = null;
            Profesor profesorDisponible = null;

            bool encontroProfesor = false;

            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor == clase)
                {
                    profesorDisponible = profesor;
                    encontroProfesor = true;
                    break;
                }
            }


            if (encontroProfesor)
            {
                Jornada jornada = new Jornada(clase, profesorDisponible);

                foreach (Alumno alumnoAux in universidad.alumnos)
                {
                    if (alumnoAux == clase)
                    {
                        jornada += alumnoAux;
                    }
                }

                universidad.jornadas.Add(jornada);
                universidadAux = universidad;

            }
            else
            {
                throw new SinProfesorException("No hay profesor para la clase");
            }

            return universidadAux;
        }

        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            bool repetido = false;

            foreach (Alumno alumnoAux in universidad.alumnos)
            {
                if (alumnoAux == alumno)
                {
                    repetido = true;
                    break;
                }
            }

            if (!repetido)
            {
                universidad.alumnos.Add(alumno);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }

            return universidad;
        }
        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            Universidad universidadAux = null;
            bool repetido = false;

            foreach (Profesor profesorAux in universidad.profesores)
            {
                if (profesorAux == profesor)
                {
                    repetido = true;
                    break;
                }
            }

            if (!repetido)
            {
                universidad.profesores.Add(profesor);
                universidadAux = universidad;
            }

            return universidad;
        }

        


    }
}
