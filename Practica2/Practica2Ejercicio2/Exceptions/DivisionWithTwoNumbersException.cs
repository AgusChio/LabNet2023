using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Ejercicio2.Exceptions
{
    internal class DivisionWithTwoNumbersException
    {
        public static void ThrowException()
        {
            try
            {
                Console.WriteLine("Ingrese el dividendo: ");
                string dividendoStringInput = Console.ReadLine();

                Console.WriteLine("Ingrese el divisor: ");
                string divisorStringInput = Console.ReadLine();

                double result = DivideNumbers(dividendoStringInput, divisorStringInput);
                Console.WriteLine("Este es tu resultado de division: " + result);
            }

            catch (DivideByZeroException)
            {
                Console.WriteLine("¡Solo Chuck Norris divide por cero! ¡Y sobrevive para contarlo!");
            }

            catch (FormatException)
            {
                Console.WriteLine("¡Seguro ingresó una letra o no ingresó nada! No puedo dividir palabras ni el vacío.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error inesperado: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Operación completada. Gracias por usarme :)");
            }
        }

        private static double DivideNumbers(string dividendoString, string divisorString)
        {
            double dividedndoDouble, divisorDouble;

            if (!double.TryParse(dividendoString, out dividedndoDouble) || !double.TryParse(divisorString, out divisorDouble))
            {
                throw new FormatException("Valores invalidos ¿Que clase de numero son esos?");
            }

            else if (divisorDouble == 0)
            {
                throw new DivideByZeroException("¡Solo Chuck Norris divide por cero! ¡Y el resultado es infinito!");
            }

            else
            {
                return dividedndoDouble / divisorDouble;
            }
        }
    }
}
