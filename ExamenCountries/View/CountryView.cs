using ExamenCountries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCountries.View
{
    public class CountryView
    {
        public static void ShowMenu()
        {
            Console.WriteLine("===== Countries api =====");
            Console.WriteLine("1. Buscar el pais por nombre");
            Console.WriteLine("2. Listar paises guardados");
            Console.WriteLine("3. Salir");
            Console.WriteLine("==========================");
        }

        public static void ShowCharacter(SavedItem country)
        {
            Console.WriteLine($"Nombre: {country.Name}");
            Console.WriteLine($"Estado: {country.Capital}");
            Console.WriteLine($"Especie: {country.Region}");
            Console.WriteLine($"Género: {country.Population}");
        }

        public static void ShowList(List<SavedItem> list)
        {
            Console.WriteLine("=== MIS PAÍSES ===");

            if (list.Count == 0)
            {
                Console.WriteLine("No tienes paises guardados todavía.");
                return;
            }

            int index = 1;
            foreach (var item in list)
            {
                Console.WriteLine($"{index}. {item.Name} ({item.Capital} - {item.Region} - {item.Population})");
                index++;
            }
        }
    }
}
