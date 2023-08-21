using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Ejercicio4.Exceptions
{
    internal class Logic
    {
        public static void ThrowCustomException()
        {
            throw new CustomException("Mensaje de error personalizado.");
        }
    }
}
