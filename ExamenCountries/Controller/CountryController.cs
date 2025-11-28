using ExamenCountries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                ApiResponse? apiResponse = JsonSerializer.Deserialize<ApiResponse>(content);

                if (apiResponse?.Results == null || apiResponse.Results.Count == 0)
                {
                    Console.WriteLine("No se encontraron países.");
                    return null;
                }

                Country countries= apiResponse.Results.FirstOrDefault();
                if (countries == null)
                    return null;

                return new SavedItem
                {
                    Name = countries.Name,
                    Capital = countries.Capital,
                    Region = countries.Region,
                    Population = countries.Population
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
