using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TransportePublico[] transportes = new TransportePublico[10];

            int pasajeros;

            for (int i = 0; i < 5; i++)
            {
                bool esNumero = false;

                while (!esNumero)
                {
                    Console.WriteLine($"Ingrese la cantidad de entre 1 a 4 para el Taxi numero {i + 1}");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out pasajeros))
                    {
                        Console.WriteLine("No te lo dije antes por que pense que era obvio, no se peuden ingresar letras ya que te pidoque ingreses un numero entre el 1 y el 4, gracias.");
                    }
                    else if (pasajeros >= 1 && pasajeros <= 4)
                    {
                        esNumero = true;
                    }
                    else
                    {
                        Console.WriteLine("Te dije que ingreses una cantidad entre 1 a 4 de pasajeros. Intenta de nuevo, creo en vos!");
                    }
                    transportes[i] = new Taxi(pasajeros);
                }

              
            }

            for (int i = 0; i < 5; i++)
            {
                bool esNumero = false;

                while (!esNumero)
                {
                    Console.WriteLine($"Ingresa la cantidad de entre 1 a 300 para el Ómnibus número {i + 1}");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out pasajeros))
                    {
                        Console.WriteLine("Ya te lo dije no podes ingresar palabras o letras. Ahora se ingresa de un numero que este entre el 1 y el 300, gracias.");
                    }
                    else if (pasajeros >= 1 && pasajeros <= 300)
                    {
                        esNumero = true;
                    }
                    else
                    {
                        Console.WriteLine("Te dije que ingreses una cantidad entre 1 a 300 de pasajeros. Intenta de nuevo, creo en vos!");
                    }
                    transportes[i + 5] = new Omnibus(pasajeros);
                }

            }


            foreach (TransportePublico transporte in transportes)
            {
                Console.Write($"{transporte.GetType().Name}: {transporte.Getpasajeros}" + "pasajeros");
            }

            Console.ReadKey();
        }

    }
}
