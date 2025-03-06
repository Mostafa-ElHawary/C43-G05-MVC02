using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MVC01G02.Controllers
{
    public class MovieController : Controller
    {
      // GET: /Movie/Index
        public IActionResult Index()
        {
            return View(); // Returns the Index view (Movie list)
        }

        // GET: /Movie/Details/{id}
        public IActionResult Details(int id)
        {
            // Fetch movie details based on id (replace with your data access logic)
            var movie = new { Id = id, Title = "Movie Title", Description = "Movie Description" };
            return View(movie); // Returns the Details view with movie data
        }

        // GET: /Movie/Create
        public IActionResult Create()
        {
            return View(); // Returns the Create view (form to add a new movie)
        }

        // POST: /Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken] //prevent cross-site request forgery
        public IActionResult Create(string title, string description, string genre)
        {
            // Save the new movie (replace with your data access logic)

            //After creating redirect to Index
            return RedirectToAction(nameof(Index));
        }

        // GET: /Movie/Edit/{id}
        public IActionResult Edit(int id)
        {
            // Fetch movie details based on id (replace with your data access logic)
            var movie = new { Id = id, Title = "Movie Title", Description = "Movie Description" };
            return View(movie); // Returns the Edit view with movie data
        }

        // POST: /Movie/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string title, string description, string genre)
        {
            // Update the movie (replace with your data access logic)

            return RedirectToAction(nameof(Index));
        }

        // GET: /Movie/Delete/{id}
        public IActionResult Delete(int id)
        {
            // Fetch movie details based on id (replace with your data access logic)
            var movie = new { Id = id, Title = "Movie Title", Description = "Movie Description" };
            return View(movie); // Returns the Delete view with movie data
        }

        // POST: /Movie/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            // Delete the movie (replace with your data access logic)

            return RedirectToAction(nameof(Index));
        }

        // GET: /Movie/Search
        public IActionResult Search(string searchTerm)
        {
            // Search movies based on searchTerm (replace with your data access logic)
            var movies = new List<object>(); //Movies list searching
            return View(movies); // Returns the Search view with search results
        }

        // GET: /Movie/DetailsView/{id}
        [HttpGet("Movie/DetailsView/{id}")]
        public IActionResult DetailsView(int id)
        {
            ViewData["Id"] = id;
            return View();
        }
    }
}
