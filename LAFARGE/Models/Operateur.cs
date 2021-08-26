using System;
using System.Collections.Generic;

#nullable disable

namespace LAFARGE.Models
{
    public partial class Operateur
    {
        public Operateur()
        {
            Commandes = new HashSet<Commande>();
        }

        public string CinOperateur { get; set; }
        public string PasswordOperateur { get; set; }
        public string FullnameOperateur { get; set; }
        public string NumeroOperateur { get; set; }
        public string AdresseOperateur { get; set; }

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
