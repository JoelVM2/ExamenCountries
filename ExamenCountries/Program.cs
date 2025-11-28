using ExamenCountries.Controller;
using ExamenCountries.Model;
using static ExamenCountries.View.CountryView;

public class Program
{
    static List<SavedItem> characterList = new List<SavedItem>();

    static async Task Main(string[] args)
    {
        while (true)
        {
            ShowMenu();
            Console.Write("Opción: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int opc))
            {
                Console.WriteLine("Introduce un número válido.");
                continue;
            }

            switch (opc)
            {
                case 1:
                    await GetCharacter();
                    break;

                case 2:
                    ShowList(characterList);
                    Console.WriteLine("\nPulsa ENTER para volver al menú...");
                    Console.ReadLine();
                    break;

                case 3:
                    Console.WriteLine("Saliendo...");
                    return;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        }
    }

    public async static Task GetCharacter()
    {
        CountryController controller = new CountryController();
        Console.WriteLine("Introduce el nombre del pais:");
        string name = Console.ReadLine() ?? "";

        SavedItem countries = await controller.GetCharacterAsync(name);

        if (countries == null)
        {
            //Console.Clear();
            Console.WriteLine("Personaje no encontrado.");
            return;
        }

        ShowCharacter(countries);

        Console.WriteLine("\n¿Quieres guardarlo en tu lista? (s/n)");
        string confirmation = Console.ReadLine()?.Trim().ToLower();

        if (confirmation == "s")
        {
            characterList.Add(countries);
            Console.WriteLine("Guardado correctamente.");
        }
    }
}