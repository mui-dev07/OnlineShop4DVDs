using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlineShop4DVDs.Models;
using System.Diagnostics;

namespace onlineShop4DVDs.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly Shop4DvdsContext context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(Shop4DvdsContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Include the Category, Artist, Producer, and Songs in the Albums query
            var albums = await context.Albums
                .Include(p => p.Artist)
                .Include(p => p.Producer)
                .Include(p => p.Songs)
                .Include(p => p.Category)  // Include Category in the Albums query
                .ToListAsync();

            // Fetch all Artists, Producers, and Songs
            var artists = await context.Artists.ToListAsync();
            var producers = await context.Producers.ToListAsync();
            var songs = await context.Songs.ToListAsync();

            // Fetch Games and Movies, including their Categories
            var games = await context.Games
                .Include(g => g.Category)
                .ToListAsync();
            var movies = await context.Movies
                .Include(m => m.Category)
                .ToListAsync();

            // Create the ViewModel with the necessary data
            var viewModel = new ShopModelView
            {
                ShopAlbum = albums,
                ShopArtist = artists,
                ShopProducer = producers,
                ShopSong = songs,
                ShopGame = games,
                ShopMovie = movies
            };

            return View(viewModel);
        }


        public IActionResult albumStore()
        {
            return View();
        }

        public IActionResult events()
        {
            return View();
        }

        public IActionResult news()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> contact(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                context.ContactMessages.Add(model);
                await context.SaveChangesAsync();

                ViewBag.ContactMessage = "Your Message Has Been Send Successfully ";
            }

            return View(model);
        }

        public IActionResult elements()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
