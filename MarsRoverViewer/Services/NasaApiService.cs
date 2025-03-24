using MarsRoverViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarsRoverViewer.Services
{
    public class NasaApiService
    {
        private readonly HttpClient _http = new();
        private readonly string _apiKey;

        public NasaApiService()
        {
            _apiKey = Environment.GetEnvironmentVariable("NASA_API_KEY") ?? "DEMO_KEY";
        }

        /// <summary>
        /// Gets photos by the chosen rover from a chosen date
        /// </summary>
        /// <param name="rover">Curiosity, Opportunity or Spirit</param>
        /// <param name="date">Date of the photograph</param>
        /// <returns>The JSON entry with the chosen specifications, otherwise an empty list</returns>
        public async Task<List<Photo>> GetPhotosAsync(string rover, DateTime date)
        {
            string url = $"https://api.nasa.gov/mars-photos/api/v1/rovers/{rover.ToLower()}/photos?earth_date={date:yyyy-MM-dd}&api_key={_apiKey}";
            var json = await _http.GetStringAsync(url);
            var doc = JsonSerializer.Deserialize<PhotoApiResponse>(json);

            return doc?.Photos ?? new();
        }
    }
}
