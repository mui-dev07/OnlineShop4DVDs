using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onlineShop4DVDs.Controllers;
using onlineShop4DVDs.Models;



namespace onlineShop4DVDs.Controllers
{
    public class LoginController : Controller
    {
        private readonly Shop4DvdsContext context;

        public LoginController(Shop4DvdsContext context)
        {
            this.context = context;
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
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "An error occurred while registering. Please try again.");
                    return View(model);
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult UserProfile(int id)
        {
            var user = context.UserCreds.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserProfile(UserCred user)
        {

            context.Update(user);
            context.SaveChanges();
            return View(user);


        }


        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetString("UserID");
                int aa = Convert.ToInt32(userId);
                var user = context.UserCreds.Find(aa);

                if (user == null)
                {
                    return NotFound();
                }


                user.Password = model.Password; // Ensure you hash the password before saving
                context.Update(user);
                await context.SaveChangesAsync();

                return View("UserProfile","Login");
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
                    HttpContext.Session.SetString("ProfilePicture", user.ProfilePicture);
                    return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
