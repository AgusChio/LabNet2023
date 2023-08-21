using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Ejercicio4.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        { 
        }
    }
}
