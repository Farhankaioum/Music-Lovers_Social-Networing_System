using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GigHub.Web.Data;
using GigHub.Web.Models;
using GigHub.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GigHub.Web.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GigsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // For creating Gigs
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {

            var viewModel = new GigFormViewModel {

                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View(viewModel);
            }
                

            //var artist =  await _userManager.GetUserAsync(User);
            var artistId = _userManager.GetUserId(User);

            //var genre = _context.Genres.Single(g => g.Id == model.Genre);

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var user = _context.Users.Single(u => u.Id == userId);

            var gig = new Gig
            {
                ArtistId = artistId,
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
