namespace API_287.Models
{
    public class Author
    {
        public int id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<Book>? Livres { get; set; }
    }
}