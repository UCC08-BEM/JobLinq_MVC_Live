using System;
using System.Collections.Generic;

namespace JobLinq_MVC_Live.Models
{
    public partial class PrmHesapTipi
    {
        public PrmHesapTipi()
        {
            TblDatUsers = new HashSet<TblDatUser>();
        }

        public int Id { get; set; }
        public string? HesapTipi { get; set; }

        public virtual ICollection<TblDatUser> TblDatUsers { get; set; }
    }
}
