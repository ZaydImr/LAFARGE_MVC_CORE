using System;
using System.Collections.Generic;

#nullable disable

namespace LAFARGE.Models
{
    public partial class Client
    {
        public Client()
        {
            Commandes = new HashSet<Commande>();
            HistoriqueChecks = new HashSet<HistoriqueCheck>();
        }

        public int CodeClient { get; set; }
        public string NomClient { get; set; }
        public string NumeroClient { get; set; }
        public string SituationFinanciere { get; set; }
        public double SoldeClient { get; set; }
        public string AdresseClient { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
        public virtual ICollection<HistoriqueCheck> HistoriqueChecks { get; set; }
    }
}
