using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace JobLinq_MVC_Live.Models
{
    public partial class Advert
    {
        public int AdvertId { get; set; }

        [DisplayName("Şirket ID")] // db deki tablo alanının ne gibi görünmesini istiyorsak.(Display Name Attribute ile düzenleyebiliyoruz.
        public int? CompanyId { get; set; }
        [DisplayName("İlan Başlığı")]
        public string? AdvertTitle { get; set; }
        [DisplayName("İlan Detayı")]
        public string? AdvertDetail { get; set; }
        [DisplayName("Şehir")]
        public byte? CityId { get; set; }
        [DisplayName("İş Tipi")]
        public string? JobType { get; set; }
    }
}
