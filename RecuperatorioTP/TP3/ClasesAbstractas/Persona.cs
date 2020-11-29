using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace ClasesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;


        public Persona()
        {
            
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = ValidarDni(nacionalidad, dni);
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = ValidarDni(nacionalidad, dni);
            this.nacionalidad = nacionalidad;
        }
        public string Nombre
        {
            get
            {
                if (String.IsNullOrWhiteSpace(nombre))
                {
                    return "Nombre nulo o vacio";
                }
                else
                {
                    return nombre;
                }
            }
            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                if (String.IsNullOrWhiteSpace(apellido))
                {
                    return "Apellido nulo o vacio";
                }
                else
                {
                    return apellido;
                }
            }

            set
            {
                apellido = value;
            }
        }

        public int DNI
        {
            get
            {
                if (ValidarDni(nacionalidad, dni) != 0)
                {
                    return dni;
                }

                throw new NacionalidadInvalidaException("El DNI ingresado no pertenece a esa nacionalidad");
            }

            set
            {
                if (ValidarDni(nacionalidad, value) != 0)
                {
                    dni = value;
                }

                throw new NacionalidadInvalidaException("El DNI ingresado no pertenece a esa nacionalidad");
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            { return nacionalidad;}
            set
            { nacionalidad = value; }
        }
        public string StringToDNI
        {
            set { }   
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"NOMBRE COMPLETO: {apellido}, {nombre}");
            sb.AppendLine($"NACIONALIDAD: {nacionalidad}");

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int.TryParse(dato, out int dni);

            if (dni == 0)
            {
                throw new DniInvalidoException("El DNI no cumple con caracteres válidos");
            }

            return this.ValidarDni(nacionalidad, dni);
        }
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato.ToString().Length > 8)
            {
                throw new DniInvalidoException("ERROR. DNI demasiado largo.");
            }
            if(dato.ToString().Length < 1)
            {
                throw new DniInvalidoException("ERROR. DNI demasiado corto");
            }
            if ( dato.ToString() == null)
            {
                throw new DniInvalidoException("ERROR. DNI invalido");
            }

            bool dniValido;

            if (nacionalidad == ENacionalidad.Argentino)
            {
                dniValido = dato >= 1 && dato <= 89999999;
            }
            else
            {
                dniValido = dato >= 90000000 && dato <= 99999999;
            }

            int retorno = dniValido ? dato : 0;

            if (retorno == 0)
            {
                throw new NacionalidadInvalidaException("El DNI ingresado no pertenece a esa nacionalidad");
            }

            return retorno;
        }

       

        private string ValidarNombreApellido(string dato)
        {
            if (String.IsNullOrWhiteSpace(dato))
            {
                return "Nombre y apellido no ingresados";
            }

            return dato;
        }

    }
}
