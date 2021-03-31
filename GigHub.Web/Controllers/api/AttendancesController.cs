using System.Security.Claims;
using GigHub.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace GigHub.Web.Controllers.api
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Attend(int objId)
        {
            if (objId == null)
                return BadRequest("Gig should not empty or null.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var existsAttendance = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == objId);

            //if (existsAttendance)
            //    return BadRequest("You are already attendance this event");

            //var attendace = new Attendance
            //{
            //    GigId = objId,
            //    AttendeeId = userId
            //};

            //_context.Attendances.Add(attendace);
            //_context.SaveChanges();

            return Ok();
        }
    }
}
