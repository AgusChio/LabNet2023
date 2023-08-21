using Practica2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al divisor por cero. Espero que estes listo para esto.");
            DivisionExeptions.ThrowException();
        }
    }
}
