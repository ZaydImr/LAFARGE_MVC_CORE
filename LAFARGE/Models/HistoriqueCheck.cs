using System;
using System.Collections.Generic;

#nullable disable

namespace LAFARGE.Models
{
    public partial class HistoriqueCheck
    {
        public int CodeClient { get; set; }
        public string CheckClient { get; set; }

        public virtual Client CodeClientNavigation { get; set; }
    }
}
