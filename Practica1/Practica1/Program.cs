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
                        Console.WriteLine("eh no se aceptan letras y palabras. Vamos de nuevo ingresa un numero entre entre el 1 al 4");
                    }
                    else if (pasajeros >= 1 && pasajeros <= 4)
                    {
                        esNumero = true;
                    }
                    else if(pasajeros > 4)
                    {
                        Console.WriteLine("Em creo que no es un auto de payasos para que ingreses esa cantidad");
                    }
                    else if (pasajeros <= 0)
                    {
                        Console.WriteLine("Que estas ingresando loco? Dale vos podes un numero entre el 1 y 4.");
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
                        Console.WriteLine("eh no se aceptan letras y palabras. Vamos de nuevo ingresa un numero entre entre el 1 al 300");
                    }
                    else if (pasajeros >= 1 && pasajeros <= 300)
                    {
                        esNumero = true;
                    }
                    else if (pasajeros > 300)
                    {
                        Console.WriteLine("Em esta bien que el micro sea de capacidad de 300 pero te pasaste. Vamos de nuevo, ingresa un numero del 1 al 300.");
                    }
                    else if (pasajeros <= 0)
                    {
                        Console.WriteLine("Seguis loquito? Dale vos podes un numero entre el 1 y 300.");
                    }

                    transportes[i + 5] = new Omnibus(pasajeros);
                }

            }


            foreach (TransportePublico transporte in transportes)
            {
                Console.Write($"Trasporte publico {transporte.GetType().Name}: {transporte.Traerpasajeros}" + " pasajeros.");

                if (transporte is Taxi taxi)
                {
                    Console.WriteLine(taxi.Avanzar());
                    Console.WriteLine(taxi.Detener());
                }
                else if (transporte is Omnibus omnibus)
                {
                    Console.WriteLine(omnibus.Avanzar());
                    Console.WriteLine(omnibus.Detener());
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

    }
}
