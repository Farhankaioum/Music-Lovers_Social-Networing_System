using System.Linq;
using System.Security.Claims;
using GigHub.Web.Data;
using GigHub.Web.Dtos;
using GigHub.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GigHub.Web.Controllers.api
{
    public class Test
    {
        public int GigId { get; set; }
    }

    [Authorize]
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
        public IActionResult Attend([FromBody]AttendanceDto attendanceDto)
        {
            if (attendanceDto.GigId == null)
                return BadRequest("Gig should not empty or null.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var existsAttendance = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == attendanceDto.GigId);

            if (existsAttendance)
                return BadRequest("You are already attendance this event");

            var attendace = new Attendance
            {
                GigId = attendanceDto.GigId.Value,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendace);
            _context.SaveChanges();

            return Ok();
        }
    }
}
