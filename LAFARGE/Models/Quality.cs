using System;
using System.Collections.Generic;

#nullable disable

namespace LAFARGE.Models
{
    public partial class Quality
    {
        public Quality()
        {
            Commandes = new HashSet<Commande>();
        }

        public int IdQuality { get; set; }
        public string NameQuality { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
