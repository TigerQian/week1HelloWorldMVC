using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Linq;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<Movie> _sampleData = new List<Movie> 
        {
            new Movie { Title = "The Shawshank Redemption", Genre = "Drama" },
            new Movie { Title = "The Godfather", Genre = "Crime" },
            new Movie { Title = "The Dark Knight", Genre = "Action" },
            new Movie { Title = "Pulp Fiction", Genre = "Crime" },
            new Movie { Title = "The Lord of the Rings: The Return of the King", Genre = "Fantasy" }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Search(string query, string genre)
        {
            var results = _sampleData.Where(m => (string.IsNullOrEmpty(query) || m.Title.Contains(query, StringComparison.OrdinalIgnoreCase)) 
                                                 && (string.IsNullOrEmpty(genre) || m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))).ToList();
            ViewData["Query"] = query;
            ViewData["Genre"] = genre;
            return View(results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
