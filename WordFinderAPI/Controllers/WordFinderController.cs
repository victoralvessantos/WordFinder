using Microsoft.AspNetCore.Mvc;
using WordFinder.Core.Interfaces;

namespace WordFinderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordFinderController : ControllerBase
    {

        private readonly ILogger<WordFinderController> _logger;
        private readonly IWordFinderService _wordFinderService;

        public WordFinderController(
            ILogger<WordFinderController> logger,
            IWordFinderService wordFinderService)
        {
            _logger = logger;
            _wordFinderService = wordFinderService;
        }

        [HttpPost(Name = "Find")]
        public IEnumerable<string> Find(
            WordFinderFindParameter parameter)
        {
            if (parameter?.Matrix == null || parameter?.WordStream == null)
                return Enumerable.Empty<string>();

            return _wordFinderService.Find(
                parameter.Matrix,
                parameter.WordStream);
        }
    }
}
