using System;
using System.Collections.Generic;

namespace JobLinq_MVC_Live.Models
{
    public partial class PrmSektorBilgisi
    {
        public PrmSektorBilgisi()
        {
            DatSirkets = new HashSet<DatSirket>();
            TblSirketBilgisis = new HashSet<TblSirketBilgisi>();
        }

        public int SektorId { get; set; }
        public string? SektorName { get; set; }

        public virtual ICollection<DatSirket> DatSirkets { get; set; }
        public virtual ICollection<TblSirketBilgisi> TblSirketBilgisis { get; set; }
    }
}
