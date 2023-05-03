using System;
using System.Collections.Generic;

namespace JobLinq_MVC_Live.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? UserType { get; set; } // Kullanıcın tipi için
    }
}
