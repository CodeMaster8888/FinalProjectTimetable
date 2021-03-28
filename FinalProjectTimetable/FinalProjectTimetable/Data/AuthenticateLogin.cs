﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectTimetable.Data
{
    public class AuthenticateLogin
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}