using Practica2Ejercicio3.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Logic.ThrowException();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Ajá atrape una excepcion, vas a mi coleccion de excepciones muajajaja");
                Console.WriteLine("Tipo de excepción: " + ex.GetType());
                Console.WriteLine("Mensaje de excepción: " + ex.Message);
            }

            finally
            {
                Console.WriteLine("La captura llego a su fin, mañana sera otro dia para capturar mas! Si desea salir presione ENTER");
                Console.ReadLine();
            }
        }
    }
}
