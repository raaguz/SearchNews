using System.Text.Json;

namespace SearchNews.ExternalServices
{
    public class HackerNewsItem
    {
        public string? By { get; set; }
        public int Descendants { get; set; }
        public int Id { get; set; }
        public int[]? Kids { get; set; }
        public int Score { get; set; }
        public long Time { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
    }

    public class HackerNewsApiService
    {
        private readonly HttpClient _httpClient;

        public HackerNewsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<int>> GetBestStoriesIdsAsync()
        {
            string url = "https://hacker-news.firebaseio.com/v0/beststories.json";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar el JSON a una lista de enteros (IDs)
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var bestStoryIds = JsonSerializer.Deserialize<List<int>>(responseBody, options);

                if (bestStoryIds != null)
                {
                    return bestStoryIds;
                }
                else
                {
                    throw new Exception("Error al deserializar la respuesta del API");
                }
            }
            else
            {
                throw new HttpRequestException($"Error en la solicitud al API de Hacker News: {response.StatusCode}");
            }
        }

        public async Task<HackerNewsItem> GetHackerNewsItemAsync(int itemId)
        {
            string url = $"https://hacker-news.firebaseio.com/v0/item/{itemId}.json";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserializar el JSON a un objeto HackerNewsItem
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var hackerNewsItem = JsonSerializer.Deserialize<HackerNewsItem>(responseBody, options);

                if (hackerNewsItem != null)
                {
                    return hackerNewsItem;
                }
                else
                {
                    throw new Exception("Error al deserializar la respuesta del API");
                }
            }
            else
            {
                throw new HttpRequestException($"Error en la solicitud al API de Hacker News: {response.StatusCode}");
            }
        }
    }
}
