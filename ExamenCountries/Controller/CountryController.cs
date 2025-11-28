using ExamenCountries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamenCountries.Controller
{
    internal class CountryController
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<SavedItem> GetCharacterAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            Console.WriteLine("Buscando...");

            try
            {
                var url = $"https://restcountries.com/v3.1/name/{name}";
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error en la respuesta HTTP: {response.StatusCode}");
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // La API devuelve un array de países
                List<Country>? countries = JsonSerializer.Deserialize<List<Country>>(content, options);

                if (countries == null || countries.Count == 0)
                {
                    Console.WriteLine("No se encontraron países.");
                    return null;
                }

                Country country = countries.First();

                return new SavedItem
                {
                    Name = country.Name.Common,
                    Capital = country.Capital?.FirstOrDefault() ?? "N/A",
                    Region = country.Region,
                    Population = country.Population, // long → long
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el país: {ex.Message}");
                return null;
            }
        }
    }
}
