using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Omnibus : TransportePublico
    {
        public Omnibus(int pasajeros) : base(pasajeros) { }

        public override string Avanzar()
        {
            return $"El omnibus con {Getpasajeros} pasajeros avanza a la siguiente parada.";
        }

        public override string Detener()
        {
            return $"El omnibus con {Getpasajeros} pasajeros se va a detener.";
        }
    }
}
