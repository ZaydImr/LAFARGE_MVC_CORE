using System;
using System.Collections.Generic;

#nullable disable

namespace LAFARGE.Models
{
    public partial class Chauffeur
    {
        public Chauffeur()
        {
            Commandes = new HashSet<Commande>();
        }

        public string CinChauffeur { get; set; }
        public string FullnameChauffeur { get; set; }
        public string NumeroChauffeur { get; set; }
        public string AdresseChauffeur { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
