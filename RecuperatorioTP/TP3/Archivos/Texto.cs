using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto
    {

        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, true))
                {
                    sw.WriteLine(datos);
                }

                retorno = true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex.Message);
            }

            return retorno;
        }


        public bool Leer(string archivo, out string datos)
        {   
            datos = string.Empty;
            bool retorno = false;
            
            if (File.Exists(archivo))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(archivo))
                    {
                        while ((datos = sr.ReadLine()) != null)
                        {
                            datos += datos + "\n";
                        }
                    }

                    retorno = true;
                }
                catch (Exception ex)
                {
                    throw new ArchivosException(ex.Message);
                }

            }
            else
            {
                throw new ArchivosException("El archivo txt no puede ser leído");
            }

            return retorno;
        }
    }
}
