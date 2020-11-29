using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public sealed class Pelicula : Producto
    {
        public enum tipoPelicula
        {
            Accion,
            Drama,
            Fantasia,
            Terror
        }
        private int id;
        private string nombre;
        private tipoPelicula tipo;
        private float precio;
        private int cantidadDeStock;
        public Pelicula()
        {

        }
    
        
        public Pelicula(int id, string nombre, tipoPelicula tipo, float precio,int cantidadStock) : base(id, nombre, precio)
        {
           
            this.tipo = tipo;
            this.cantidadDeStock = cantidadStock;
        }

       

        public tipoPelicula Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }
       
        public static bool operator ==(Pelicula peliculaItem, List<Pelicula> listaPeliculas)
        {
            bool retorno = false;

            foreach (Pelicula pelicula in listaPeliculas)
            {
                if (pelicula.Nombre == peliculaItem.Nombre)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        public static bool operator !=(Pelicula peliculaItem, List<Pelicula> listaPeliculas)
        {
            return !(peliculaItem == listaPeliculas );
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID: {id}");
            sb.AppendLine($"Nombre: {nombre}");
            sb.AppendLine($"Tipo: {tipo}");
            sb.AppendLine($"Precio: {precio}");
            //sb.AppendLine("--------------------------------");

            return sb.ToString();
        }
    }
}
