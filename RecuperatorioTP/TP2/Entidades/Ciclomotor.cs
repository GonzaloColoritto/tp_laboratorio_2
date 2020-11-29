using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color):base(chasis,marca,color)
        {
            
        }
        
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            /*
            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(this.ToString());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}" );
            sb.AppendLine("");
            sb.AppendLine("---------------------");*/

            sb.AppendLine($"TAMAÑO: {Tamanio}\r");
            sb.AppendLine("---------------------");

            return "CICLOMOTOR\n" + base.Mostrar() + sb.ToString();

            //return sb.ToString();
        }
    }
}
