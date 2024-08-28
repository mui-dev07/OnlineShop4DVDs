using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlineShop4DVDs.Models;
using System.Diagnostics;

namespace onlineShop4DVDs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Shop4DvdsContext context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(Shop4DvdsContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            // Fetch albums and related data using the foreign key relationships
            var model = context.Albums
                .Include(a => a.Songs)
                .Include(a => a.Artists) // Include artists
                .Include(a => a.Categories) // Include categories
               /* .Include(a => a.Feedbacks)*/ 
                                           // Add more includes as needed
                .Select(a => new ShopModelView
                {
                    ShopAlbum = a,
                    ShopSong = a.Songs.ToList(),
                    ShopArtist = a.Artists.ToList(),
                    ShopCategory = a.Categories.ToList(),
                    //ShopFeedback = a.Feedbacks.ToList(),
                    // Add other entities to the ShopModelView
                })
                .ToList();

            return View(model);
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

        public IActionResult elements()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> register(UserCred model, IFormFile profilePicture)
        {
            if (profilePicture == null || profilePicture.Length == 0)
            {
                ModelState.AddModelError("ProfilePicture", "Profile Picture is required.");
            }

            if (ModelState.IsValid)
            {
                // Create a new UserCred object
                UserCred user = new UserCred
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Email = model.Email,
                    Username = model.Username,
                    DateOfBirth = model.DateOfBirth,
                    Password = model.Password
                };

                // Handle profile picture upload
                if (profilePicture != null && profilePicture.Length > 0)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UP-Assets/img/pfp");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(profilePicture.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await profilePicture.CopyToAsync(fileStream);
                    }

                    user.ProfilePicture = "/UP-Assets/img/pfp/" + uniqueFileName;
                }

                try
                {
                    await context.UserCreds.AddAsync(user);
                    await context.SaveChangesAsync();

                    HttpContext.Session.SetString("UserID", user.Id.ToString());

                    ModelState.Clear();
                    ViewBag.registerMessage = $"{user.Firstname} {user.Lastname} Registered Successfully.";

                    return RedirectToAction("Login");
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "An error occurred while registering. Please try again.");
                    return View(model);
                }
            }

            return View(model);
        }



        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult login(loginView model)
        {
            if (ModelState.IsValid)
            {
                var user = context.UserCreds.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    HttpContext.Session.SetString("UserID", user.Id.ToString());
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    HttpContext.Session.SetString("UserName", user.Username);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.LoginMessage = "Login Failed";
                }
            }
            return View();
        }

        public IActionResult logout()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                HttpContext.Session.Remove("UserID");
                HttpContext.Session.Remove("UserEmail");
                HttpContext.Session.Remove("UserName");
                return RedirectToAction("Index");
            }
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
