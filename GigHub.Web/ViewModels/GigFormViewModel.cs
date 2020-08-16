using GigHub.Web.CustomValidationAttribute;
using GigHub.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GigHub.Web.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Invalid date")]
        public string Date { get; set; }

        [Required]
        [ValidTime(ErrorMessage = "Invalid time")]
        public string Time { get; set; }
        
        [Required]
        public int Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime() 
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

    }
}
