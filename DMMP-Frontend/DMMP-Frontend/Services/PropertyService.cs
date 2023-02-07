using DMMP_Frontend.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP_Frontend.Services
{
    public class PropertyService
    {
        private readonly HttpClient _httpClient;

        public PropertyService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Property>> GetPropertiesAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7284/api/Property/GetAllProperties");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve properties.");
            }

            var json = await response.Content.ReadAsStringAsync();
            var properties = JsonConvert.DeserializeObject<List<Property>>(json);

            return properties;
        }
    }
}
