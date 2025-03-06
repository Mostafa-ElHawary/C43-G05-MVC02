using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MVC01G02.Controllers
{
    public class MovieController : Controller
    {
        // Acction : public non-static Method

        [HttpGet("Movie/GetMovie/{id}")]
        public IActionResult GetMovie(int id)
        {
            return Content($"Get Movie With: {id}");
        }

        // Example of returning a ViewResult
        [HttpGet("Movie/Index")]
        public IActionResult Index()
        {
            return View();
        }

        // Example of returning a JsonResult
        [HttpGet("Movie/GetMovieJson/{id}")]
        public IActionResult GetMovieJson(int id)
        {
            var movie = new { Id = id, Title = "Sample Movie" };
            return Json(movie);
        }

        // Example of returning a RedirectResult
        [HttpGet("Movie/RedirectToHome")]
        public IActionResult RedirectToHome()
        {
            return RedirectToAction("Index", "Home");
        }

        // Example of returning a ContentResult
        [HttpGet("Movie/GetContent")]
        public IActionResult GetContent()
        {
            return Content("This is a plain text content result.");
        }

        // Example of returning a NotFoundResult
        [HttpGet("Movie/MovieNotFound")]
        public IActionResult MovieNotFound()
        {
            return NotFound();
        }

        // Example of returning a BadRequestResult
        [HttpGet("Movie/BadRequestExample")]
        public IActionResult BadRequestExample()
        {
            return BadRequest("This is a bad request example.");
        }

        // Example of returning a PartialViewResult
        [HttpGet("Movie/GetPartialView")]
        public IActionResult GetPartialView()
        {
            return PartialView("_PartialViewName");
        }

        // Example of returning a FileResult
        [HttpGet("Movie/DownloadFile")]
        public IActionResult DownloadFile()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("path/to/file");
            string fileName = "downloadedFile.txt";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        // Example of returning a StatusCodeResult
        [HttpGet("Movie/CustomStatusCode")]
        public IActionResult CustomStatusCode()
        {
            return StatusCode(418); // I'm a teapot
        }

        // Example of returning a CreatedAtActionResult
        [HttpPost("Movie/CreateMovie")]
        public IActionResult CreateMovie()
        {
            var newMovie = new { Id = 1, Title = "New Movie" };
            return CreatedAtAction(nameof(GetMovieJson), new { id = newMovie.Id }, newMovie);
        }

        // Example of returning an UnauthorizedResult
        [HttpGet("Movie/UnauthorizedAccess")]
        public IActionResult UnauthorizedAccess()
        {
            return Unauthorized();
        }

        // Example of returning a ChallengeResult
        [HttpGet("Movie/ChallengeExample")]
        public IActionResult ChallengeExample()
        {
            return Challenge();
        }

        // Example of returning a SignInResult
        [HttpGet("Movie/SignInExample")]
        public IActionResult SignInExample()
        {
            var userPrincipal = new System.Security.Claims.ClaimsPrincipal();
            return SignIn(userPrincipal, "CookieAuthenticationScheme");
        }

        // Example of returning a SignOutResult
        [HttpGet("Movie/SignOutExample")]
        public IActionResult SignOutExample()
        {
            return SignOut("CookieAuthenticationScheme");
        }

        // Example of returning a LocalRedirectResult
        [HttpGet("Movie/LocalRedirectExample")]
        public IActionResult LocalRedirectExample()
        {
            return LocalRedirect("~/Home/Index");
        }

        // Example of returning a NoContentResult
        [HttpGet("Movie/NoContentExample")]
        public IActionResult NoContentExample()
        {
            return NoContent();
        }

        // Example of returning an AcceptedResult
        [HttpGet("Movie/AcceptedExample")]
        public IActionResult AcceptedExample()
        {
            return Accepted();
        }

        // Example of returning an AcceptedAtActionResult
        [HttpGet("Movie/AcceptedAtActionExample")]
        public IActionResult AcceptedAtActionExample()
        {
            return AcceptedAtAction(nameof(Index));
        }

        // Example of returning a ConflictResult
        [HttpGet("Movie/ConflictExample")]
        public IActionResult ConflictExample()
        {
            return Conflict();
        }

        // Example of returning a ProblemDetailsResult
        [HttpGet("Movie/ProblemDetailsExample")]
        public IActionResult ProblemDetailsExample()
        {
            return Problem("There was a problem with your request.");
        }

        // Example of returning a Task<IActionResult>
        [HttpGet("Movie/AsyncExample")]
        public async Task<IActionResult> AsyncExample()
        {
            await Task.Delay(1000); // Simulate async work
            return Ok("Async operation completed.");
        }

        // Example of binding parameters from Form
        [HttpPost("Movie/SubmitForm")]
        public IActionResult SubmitForm([FromForm] string title, [FromForm] int year)
        {
            return Content($"Form Data - Title: {title}, Year: {year}");
        }

        // Example of binding parameters from URL Segment
        [HttpGet("Movie/Details/{id}")]
        public IActionResult Details(int id)
        {
            return Content($"URL Segment - Movie ID: {id}");
        }

        // Example of binding parameters from Query String
        [HttpGet("Movie/Search")]
        public IActionResult Search([FromQuery] string title, [FromQuery] int year)
        {
            return Content($"Query String - Title: {title}, Year: {year}");
        }

        // Example of binding parameters from File
        [HttpPost("Movie/UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = $"uploads/{file.FileName}";
                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return Content($"File uploaded successfully: {file.FileName}");
            }
            return BadRequest("File upload failed.");
        }

        // Action method for Home page
        [HttpGet("Home")]
        public IActionResult Home()
        {
            ViewData["Title"] = "Home Page";
            return View("Index");
        }

        // Action method for About page
        [HttpGet("About")]
        public IActionResult About()
        {
            ViewData["Title"] = "About Page";
            return View("About");
        }

        // Action method for ContactUs page
        [HttpGet("ContactUs")]
        public IActionResult ContactUs()
        {
            ViewData["Title"] = "Contact Us Page";
            return View("ContactUs");
        }

        // Action method for Privacy page
        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy Page";
            return View("Privacy");
        }
    }
}
