﻿using GigHub.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GigHub.Web.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public List<Attendance> Attendances { get; set; }
    }
}
