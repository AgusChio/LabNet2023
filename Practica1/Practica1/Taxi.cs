﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Taxi : TransportePublico
    {
        public Taxi(int pasajeros) : base(pasajeros) 
        { 
        }

        public override string Avanzar()
        {
            return $"El taxi con {Traerpasajeros} pasajeros avanza a la siguiente parada.";
        }

        public override string Detener()
        {
            return $"El taxi con {Traerpasajeros} pasajeros se va a detener en la siguiente pararada";
        }
    }
}
