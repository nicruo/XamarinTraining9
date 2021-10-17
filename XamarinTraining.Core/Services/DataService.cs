using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XamarinTraining.Core.Domain;

namespace XamarinTraining.Core.Services
{
    public class DataService : IDataService
    {
        private HttpClient httpClient;

        public DataService()
        {
            httpClient = new HttpClient();
        }

        public async Task<IList<Character>> GetCharactersByNameAsync(string name)
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage resultMessage = await httpClient.GetAsync("https://rickandmortyapi.com/api/character/?name=" + name);
                string resultContent = await resultMessage.Content.ReadAsStringAsync();
                ServiceResult serviceResult = JsonConvert.DeserializeObject<ServiceResult>(resultContent);
                return serviceResult == null ? new List<Character>() : serviceResult.Result;
            });
        }

        public class ServiceResult
        {
            [JsonProperty("results")]
            public IList<Character> Result { get; set; }
        }

        public async Task<Character> GetCharacterAsync(int id)
        {
            return await Task.Run(async () =>
            {
                HttpResponseMessage resultMessage = await httpClient.GetAsync("https://rickandmortyapi.com/api/character/" + id);
                string resultContent = await resultMessage.Content.ReadAsStringAsync();
                Character character = JsonConvert.DeserializeObject<Character>(resultContent);
                return character;
            });
        }

    }
}