﻿using System;
using System.Collections.Generic;

namespace JobLinq_MVC_Live.Models
{
    public partial class JobApp
    {
        public int JobAppId { get; set; }
        public int? UserId { get; set; }
        public int? AdvertId { get; set; }
    }
}
