using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public abstract class TransportePublico
    {

        public TransportePublico(int pasajeros) 
        { 
            Getpasajeros = pasajeros;
        }

        public int Getpasajeros { get; set; }

        public abstract string Avanzar();

        public abstract string Detener();
    }
}
