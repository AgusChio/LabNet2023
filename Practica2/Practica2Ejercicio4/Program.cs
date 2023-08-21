using Practica2Ejercicio4.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Logic.ThrowCustomException();
            }

            catch (CustomException customEx)
            {
                Console.WriteLine("Que es eso que veo? es un ave? es un avion? NO, es una excepcion personalizada que capture:");
                Console.WriteLine("Tipo de excepción: " + customEx.GetType());
                Console.WriteLine("Mensaje de excepción: " + customEx.Message);
            }
            finally
            {
                Console.WriteLine("Terminó. Presione Enter para salir...");
                Console.ReadLine();
            }
            
        }
    }
}
