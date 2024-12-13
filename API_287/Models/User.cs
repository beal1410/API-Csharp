using System.ComponentModel.DataAnnotations.Schema;

namespace API_287.Models
{
    public class User
    {
        public int id {get; set;}
        public string Prenom {get; set;}
        public string Nom { get; set; }
        public string Telephone { get; set; }
        public string Couriel { get; set; }

        public int IdAdresse {get; set;}

        [ForeignKey("IdAdresse")]
        public virtual Address? Adresse { get; set; }
    }
}
