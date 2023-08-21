using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2.Exceptions
{
    internal class DivisionExeptions
    {
        public static void ThrowException()
        {
            try
            {
                Console.WriteLine("Ingrese el valor");
                string valueInput = Console.ReadLine();

                int value;
                if (int.TryParse(valueInput, out value))
                {
                    int result = DivideByZero(value);
                    Console.WriteLine("Ey si se pudo, fue exitoso. Este es el resultado: " + result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Al parecer ocurrio un error: " + ex.Message);
            }

            finally
            {
                Console.WriteLine("Operacion completada. Vuelva pronto");
            }
        }

        private static int  DivideByZero(int value)
        {
            int number = 0;

            if (value == 0)
            {
                throw new Exception("No es porsible dividirlo por cero");
            }

            return number / value;
        }
    }
}
