using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace JobLinq_MVC_Live.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }

        [DisplayName("User ID")]
        public int? UserId { get; set; }

        [DisplayName("Şirket Adı")]
        public string? Cname { get; set; }

        [DisplayName("Sektör No")]
        public byte? SectorId { get; set; }

        [DisplayName("Şirket Adres")]
        public string? Cadress { get; set; }

        [DisplayName("Şehir")]
        public byte? CityId { get; set; }
    }
}
