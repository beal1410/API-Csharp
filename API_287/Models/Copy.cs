using System.ComponentModel.DataAnnotations.Schema;

namespace API_287.Models
{
    public class Copy
    {
        public int id { get; set; }
        public string EtatDuLivre { get; set; }

        public int IdLivre { get; set; }

        [ForeignKey("IdLivre")]
        public virtual Book? Livre { get; set; }
    }
}