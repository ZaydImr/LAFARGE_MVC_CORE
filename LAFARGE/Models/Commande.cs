using System;
using System.Collections.Generic;

#nullable disable

namespace LAFARGE.Models
{
    public partial class Commande
    {
        public int BonCommande { get; set; }
        public string CinOperateur { get; set; }
        public int CodeClient { get; set; }
        public int IdQuality { get; set; }
        public double Quantity { get; set; }
        public string Unite { get; set; }
        public string Matricule { get; set; }
        public double Tare { get; set; }
        public double? TonnageReel { get; set; }
        public string CinChauffeur { get; set; }
        public DateTime? HeureChargement { get; set; }
        public DateTime? HeureLivraison { get; set; }
        public bool Verification { get; set; }

        public virtual Chauffeur CinChauffeurNavigation { get; set; }
        public virtual Operateur CinOperateurNavigation { get; set; }
        public virtual Client CodeClientNavigation { get; set; }
        public virtual Quality IdQualityNavigation { get; set; }
    }
}
