using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Practica3.Logic
{
    public class MarvelLogic
    {
        private readonly string publicKey = "f577715f526600ed57cd38d583defdef";
        private readonly string privateKey = "6795abec10c8cd4eef79b32664829d4c2a45f893";
        private readonly string baseUrl = "https://gateway.marvel.com:443/v1/public/";

        public async Task<string> GetCharactersAsync()
        {
            using (var httpClient = new HttpClient())
            {

                var timestamp = DateTime.Now.Ticks.ToString();
                var hash = MarvelApiHelper.GenerateHash(timestamp, privateKey, publicKey);

                var url = $"{baseUrl}characters?ts={timestamp}&apikey={publicKey}&hash={hash}";

                var response = await httpClient.GetStringAsync(url);

                return response;
            }
        }
    }
}
