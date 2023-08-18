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
            Traerpasajeros = pasajeros;
        }

        public int Traerpasajeros { get; }

        public abstract string Avanzar();

        public abstract string Detener();
    }
}
