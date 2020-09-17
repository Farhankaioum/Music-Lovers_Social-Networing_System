using GigHub.Web.Data;

namespace GigHub.Web.Models
{
    public class Attendance
    {
        public Gig Gig { get; set; }
        public int GigId { get; set; }

        public ApplicationUser Attendee { get; set; }
        public string AttendeeId { get; set; }

    }
}
