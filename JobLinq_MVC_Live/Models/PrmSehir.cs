using System;
using System.Collections.Generic;

namespace JobLinq_MVC_Live.Models
{
    public partial class PrmSehir
    {
        public PrmSehir()
        {
            DatIlans = new HashSet<DatIlan>();
            DatOzluks = new HashSet<DatOzluk>();
            DatSirkets = new HashSet<DatSirket>();
            TblOzlukBilgisis = new HashSet<TblOzlukBilgisi>();
            TblSirketBilgisis = new HashSet<TblSirketBilgisi>();
        }

        public int SehirId { get; set; }
        public string? SehirAdi { get; set; }

        public virtual ICollection<DatIlan> DatIlans { get; set; }
        public virtual ICollection<DatOzluk> DatOzluks { get; set; }
        public virtual ICollection<DatSirket> DatSirkets { get; set; }
        public virtual ICollection<TblOzlukBilgisi> TblOzlukBilgisis { get; set; }
        public virtual ICollection<TblSirketBilgisi> TblSirketBilgisis { get; set; }
    }
}
