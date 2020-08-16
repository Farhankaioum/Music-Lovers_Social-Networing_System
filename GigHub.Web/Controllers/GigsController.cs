using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GigHub.Web.Data;
using GigHub.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GigHub.Web.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // For creating Gigs
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new GigFormViewModel {

                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
    }
}
