using System.ComponentModel.DataAnnotations.Schema;

namespace API_287.Models
{
    public class Loan
    {
        public int id { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime? DateRetourPrev { get; set; }
        public DateTime? DateRetourReel { get; set; }

        public int IdExemplaire { get; set; }

        [ForeignKey("IdExemplaire")]
        public virtual Copy? Exemplaire { get; set; }

        public int IdUtilisateur { get; set; }

        [ForeignKey("IdUtilisateur")]
        public virtual User? Utilisateur { get; set; }
    }
}