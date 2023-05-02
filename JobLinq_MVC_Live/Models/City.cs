using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace JobLinq_MVC_Live.Models
{
    public partial class City
    {
        public byte CityId { get; set; }

        [DisplayName("Şehir Adı")]
        public string? CityName { get; set; }
    }
}
