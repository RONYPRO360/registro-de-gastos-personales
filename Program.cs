using System;
using System.Collections.Generic;


List<string> descripciones = new List<string>();
List<double> montos = new List<double>();

int opcion = 0;

do
{
    Console.WriteLine("\n=== REGISTRO DE GASTOS PERSONALES ===");
    Console.WriteLine("1. Agregar gasto");
    Console.WriteLine("2. Listar gastos");
    Console.WriteLine("3. Buscar gasto");
    Console.WriteLine("4. Salir");
    Console.Write("Seleccione una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        opcion = 0;
    }

    Console.WriteLine();

    switch (opcion)
    {
        case 1:

            Console.Write("Ingrese la descripción del gasto: ");
            string descripcion = Console.ReadLine();

            Console.Write("Ingrese el monto del gasto: ");
            string inputMonto = Console.ReadLine();

            double monto;
            bool esMontoValido = double.TryParse(inputMonto, out monto);

            if (esMontoValido && monto > 0 && !string.IsNullOrWhiteSpace(descripcion))
            {
                descripciones.Add(descripcion.Trim());
                montos.Add(monto);
                Console.WriteLine("Gasto agregado.");
            }
            else
            {
                Console.WriteLine("Datos inválidos.");
            }
            break;

        case 2:

            if (descripciones.Count == 0)
            {
                Console.WriteLine("No hay gastos.");
            }
            else
            {
                Console.WriteLine("{0,-4} {1,-20} {2}", "#", "Descripción", "Monto");

                double total = 0;

                for (int i = 0; i < descripciones.Count; i++)
                {
                    Console.WriteLine("{0,-4} {1,-20} Q {2,5:F2}", (i + 1), descripciones[i], montos[i]);
                    total += montos[i];
                }

                Console.WriteLine("Total gastado: Q {0:F2}", total);
            }
            break;

        case 3:

            Console.Write("Ingrese el texto a buscar: ");
            string busqueda = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(busqueda))
            {
                Console.WriteLine("Sin coincidencias.");
            }
            else
            {
                bool encontrado = false;

                for (int i = 0; i < descripciones.Count; i++)
                {
                    if (descripciones[i].IndexOf(busqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Console.WriteLine("{0} (Q {1:F2})", descripciones[i], montos[i]);
                        encontrado = true;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("Sin coincidencias.");
                }
            }
            break;

        case 4:
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            break;
    }

} while (opcion != 4);