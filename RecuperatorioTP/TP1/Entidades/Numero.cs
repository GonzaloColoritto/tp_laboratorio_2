using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;


        public Numero()
        {
            numero = 0;
        }
        public Numero(double num) : this()
        {
            numero = num;
        }

        public Numero(string numero) : this()
        {
            Num = Convert.ToDouble(numero);

        }

        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;
            int numeroAux;

            if (int.TryParse(strNumero, out numeroAux))
            {
                retorno = Convert.ToDouble(numeroAux);
            }

            return retorno;

        }
        private double Num
        {
            get { return numero; }
            set { numero = value; }

        }

        private double SetNumero
        {
            set { numero = ValidarNumero(value.ToString()); }
        }

        private bool EsBinario(string binario)
        {
            bool retorno = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }


                      
        public static double operator +(Numero num1, Numero num2)
        {
            double resultado;

            resultado = num1.Num + num2.Num;

            return resultado;
        }
        public static double operator *(Numero num1, Numero num2)
        {
            double resultado;

            resultado = num1.Num * num2.Num;

            return resultado;
        }
        public static double operator -(Numero num1, Numero num2)
        {
            double resultado;

            resultado = num1.Num - num2.Num;

            return resultado;
        }
        public static double operator /(Numero num1, Numero num2)
        {
            double resultado = 0;
            if (num2 == 0)
            {
                return double.MinValue;
            }
            else { resultado = num1.Num / num2.Num; }


            return resultado;
        }
        public static bool operator ==(Numero num1, double num2)
        {
            double auxNum;
            auxNum = num1.Num;

            if (auxNum == num2)
            {
                return true;
            }
            else { return false; }


        }
        public static bool operator !=(Numero num1, double num2)
        {
            double auxNum;
            auxNum = num1.Num;

            if (auxNum != num2)
            {
                return true;
            }
            else { return false; }

        }

        
        public string DecimalBinario(double numero)
        {
            string retorno = Convert.ToString((int)numero, 2);

            return retorno;
        }

        public string DecimalBinario(string numero)
        {
            int auxNum;
            int aux2;
            string retorno = "Valor inválido";
            if (int.TryParse(numero, out auxNum))
            {
                if (auxNum>=0) {
                    if (numero != "ERROR")
                    {
                        if (numero != "Valor inválido")
                        {
                            
                            retorno = Convert.ToString(auxNum, 2);
                        }
                    }
                }
            }
            return retorno;
        }
        public string BinarioDecimal(string binario)
        {
            string retorno = "Valor inválido";
            int auxNum;
            if (int.TryParse(binario, out auxNum))
            {
                if (auxNum >= 0)
                {
                    if (binario != "ERROR")
                    {
                        if (binario != "Valor inválido ")
                            if (EsBinario(binario))
                            {
                                if (String.IsNullOrEmpty(binario))
                                {
                                    retorno = "Valor inválido";
                                }
                                else
                                {
                                    retorno = Convert.ToInt32(binario, 2).ToString();
                                }

                            }

                    }
                }
            }
            return retorno;
        }
    }  
}
