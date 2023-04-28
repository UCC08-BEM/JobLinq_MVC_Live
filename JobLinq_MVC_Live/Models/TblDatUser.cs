using System;
using System.Collections.Generic;

namespace JobLinq_MVC_Live.Models
{
    public partial class TblDatUser
    {
        public TblDatUser()
        {
            TblOzlukBilgisis = new HashSet<TblOzlukBilgisi>();
            TblSirketBilgisis = new HashSet<TblSirketBilgisi>();
        }

        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Parola { get; set; }
        public int? HesapTipi { get; set; }

        public virtual PrmHesapTipi? HesapTipiNavigation { get; set; }
        public virtual ICollection<TblOzlukBilgisi> TblOzlukBilgisis { get; set; }
        public virtual ICollection<TblSirketBilgisi> TblSirketBilgisis { get; set; }
    }
}
