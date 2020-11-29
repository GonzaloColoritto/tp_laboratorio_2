using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Entidades
{
    public enum ENacionalidad
    {
        Argentino,Extranjero
    }


    abstract public class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        
        
                                                                                         //PROPIEDADES
        public string Nombre 
        {
            get { return this.nombre;}
            set { nombre = value; } 
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { apellido = value; }
        }

        public int DNI
        {
            get { return this.dni; }
            set { dni = value; }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { nacionalidad = value; }
        }

        public string StringToDNI
        {
            set { dni = System.Convert.ToInt32(value);}
        }


                                                                                         //CONSTRUCTORES
        public Persona()
        {

        }

        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.dni = dni;
        }

        protected Persona(string nombre, string apellido, ENacionalidad nacionalidad, string dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            return  nombre + apellido + nacionalidad + dni;
        }


        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;
            try
            {
                if (nacionalidad == ENacionalidad.Argentino && dato > 1 && dato < 89999999)
                {
                    retorno = 1;
                }
                if (nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999)
                {

                }
            }
            catch(Exception ex)
            {

            }
            return retorno;
        }


        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {

            try
            {
                
            }
            catch
            {

            }

            return 0;
        }
        private string ValidarNombreApellido(string dato)
        {
            string retorno = null;
            if (!string.IsNullOrWhiteSpace(dato))
            {
                if (Validaciones.ValidarCadena(dato))
                {
                    retorno = dato;
                }
            }
            //CUANDO SE USE EN UN IF POR EJ PONER QUE SEA DISTINTO DE NULL
            return retorno;
        }
    }
}
