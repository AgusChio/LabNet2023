using Practica2Ejercicio2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido. Espero que estes listo para esto por que vamos a dividir dos numeros.");
            DivisionWithTwoNumbersException.ThrowException();
            Console.ReadLine();
        }
    }
}
