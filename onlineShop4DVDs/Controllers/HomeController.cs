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

        private string TruncateDescription(string description, int wordLimit)
        {
            if (string.IsNullOrEmpty(description)) return description;

            var words = description.Split(' ').Take(wordLimit);
            return string.Join(" ", words) + (words.Count() < description.Split(' ').Length ? "..." : "");


        }


        public async Task<IActionResult> Index()
        {

            var albums = await context.Albums
                .Include(p => p.Artist)
                .Include(p => p.Producer)
                .Include(p => p.Songs)
                .Include(p => p.Category)
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


        public IActionResult dvds()
        {
            var model = new ShopModelView
            {
                ShopProduct = context.Products.Include(p => p.Category).ToList(),
                ShopCategory = context.Categories.ToList()
            };

            return View(model);
        }


        public IActionResult ProductDetails(int id)
        {
            // Fetch product details, including related data such as category, movies, albums, songs, etc.
            var product = context.Products
                            .Include(p => p.Category)
                            .Include(p => p.Category.Movies)
                            .Include(p => p.Category.Games)
                            .Include(p => p.Category.Albums)
                                .ThenInclude(a => a.Songs)
                            .Include(p => p.Category.Albums)
                                .ThenInclude(a => a.Producer)
                            .FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        public IActionResult Cart(int id)
        {   
            return View();
        }




        public IActionResult events()
        {
            return View();
        }

        public async Task<IActionResult> News(int page = 1, int pageSize = 5)
        {
            var newsList = await context.News
                .Include(n => n.Category)
                .OrderByDescending(n => n.PublishedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalNewsCount = await context.News.CountAsync();

            var viewModel = new NewsViewModel
            {
                News = newsList,
                CurrentPage = page,
                PageSize = pageSize,
                TotalNewsCount = totalNewsCount
            };

            return View(viewModel);
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
