using System.ComponentModel.DataAnnotations.Schema;

namespace API_287.Models
{
    public class Bill
    {
        public int id { get; set; }
        public decimal FraisPaye { get; set; }
        public DateTime Date { get; set; }

        public int IdEmprunt { get; set; }

        [ForeignKey("IdEmprunt")]
        public virtual Loan? Emprunt { get; set; }
    }
}