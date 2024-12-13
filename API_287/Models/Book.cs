using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_287.Models
{
    public class Book
    {
        public int id { get; set; }
        public string Code { get; set; }
        public string Titre { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }

        public int IdAuteur { get; set; }

        [ForeignKey("IdAuteur")]
        public virtual Author? Auteur { get; set; } //Permet à entity framework d'établir la relation dans la base de données
        public virtual ICollection<Copy>? Exemplaires { get; set; } //Permet de manipuler les exemplaires à partir d'un livre
    }
}