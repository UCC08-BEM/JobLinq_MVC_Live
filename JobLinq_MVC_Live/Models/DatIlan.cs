using System;
using System.Collections.Generic;

namespace JobLinq_MVC_Live.Models
{
    public partial class DatIlan
    {
        public DatIlan()
        {
            JnkBasvurus = new HashSet<JnkBasvuru>();
        }

        public int IlanId { get; set; }
        public int? SirketId { get; set; }
        public string? IlanBaslik { get; set; }
        public string? IlanDetay { get; set; }
        public int? SehirId { get; set; }
        public string? IsTip { get; set; }

        public virtual PrmSehir? Sehir { get; set; }
        public virtual DatSirket? Sirket { get; set; }
        public virtual ICollection<JnkBasvuru> JnkBasvurus { get; set; }
    }
}
