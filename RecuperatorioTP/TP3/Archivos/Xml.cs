using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;


namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(writer, datos);
                }

                retorno = true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex.Message);
            }

            return retorno;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                if (File.Exists(archivo))
                {
                    using (XmlTextReader reader = new XmlTextReader(archivo))
                    {
                        XmlSerializer desSerializador = new XmlSerializer(typeof(T));
                        datos = (T)desSerializador.Deserialize(reader);
                    }

                    retorno = true;
                }
                else
                {
                    throw new ArchivosException("El archivo XML no puede ser leido");
                }
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex.Message);
            }

            return retorno;
        }
    }
}
