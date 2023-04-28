using System;
using System.Collections.Generic;

namespace JobLinq_MVC_Live.Models
{
    public partial class DatOzluk
    {
        public int OzlukId { get; set; }
        public int? UserId { get; set; }
        public string? Uad { get; set; }
        public string? Usoyad { get; set; }
        public string? Udt { get; set; }
        public int? SehirId { get; set; }
        public string? Gsmno { get; set; }

        public virtual PrmSehir? Sehir { get; set; }
        public virtual DatUser? User { get; set; }
    }
}
