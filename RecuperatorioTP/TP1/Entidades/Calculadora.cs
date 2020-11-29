using System;

namespace Entidades
{
    public static class Calculadora
    {

        private static string ValidarOperador(char operador) 
        {
            string retorno = null;
            if(operador != '*' && operador != '/' && operador != '-' && operador != '+') 
            {
                retorno = "+";

            }
            else
            {
                retorno =  operador.ToString();
            }
            return retorno;
        }

         public static double Operar(Numero num1, Numero num2, char operador)
         {
            double resultado = 0;

            
                switch (ValidarOperador(operador))
                {
                    case "+":
                        resultado = num1 + num2;

                        break;

                    case "-":
                        resultado = num1 - num2;
                        break;

                    case "*":
                        resultado = num1 * num2;
                        break;

                    case "/":

                        resultado = num1 / num2;

                        break;

                }
            
            return resultado;
         }


    }
}
