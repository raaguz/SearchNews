using Microsoft.AspNetCore.Mvc;
using SearchNews.ExternalServices;
using SearchNews.Model;

namespace SearchNews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchEngineController
    {
        private readonly ILogger<SearchEngineController> _logger;

        private readonly HackerNewsApiService _hackerNewsApiService;

        private readonly int _sizePage = 10;

        public SearchEngineController(
            ILogger<SearchEngineController> logger,
            HackerNewsApiService hackerNewsApiService
            )
        {
            _logger = logger;
            _hackerNewsApiService= hackerNewsApiService;
        }

        [HttpGet(Name = "GetBetsStoriesDetail")]
        public async Task<ActionResult<List<StorieDTO>>> Get(int num_stories,int indexPage)
        {
            List<StorieDTO> storiResponseDTO = new List<StorieDTO>();
            HackerNewsItem item;
            StorieDTO stori;

            try
            {
                //Invoke API
                List<int> bestStoryIds = await _hackerNewsApiService.GetBestStoriesIdsAsync();
                int id;

                for (int i = (indexPage*_sizePage-_sizePage); i < indexPage * _sizePage && i < num_stories; i++)
                {
                    id = bestStoryIds[i];
                    Console.WriteLine(id);

                    item = await _hackerNewsApiService.GetHackerNewsItemAsync(id);

                    stori = new StorieDTO();
                    stori.Title = item.Title;
                    stori.Uri = item.Url;
                    stori.PostedBy = item.By;
                    stori.Time = new DateTime(item.Time);
                    stori.Score = item.Score;
                    stori.CommentCount = item.Kids is null ? 0 : item.Kids.Length;

                    storiResponseDTO.Add(stori);
                }
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
            }

            return storiResponseDTO;
        }
    }

}
