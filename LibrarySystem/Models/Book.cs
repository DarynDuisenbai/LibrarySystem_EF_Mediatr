using System.Data;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public List<Genre>   Genres { get; set; }

        //public DateOnly PublicationDate { get; set; }
        public DateTime  PublicationDate { get; set; }
    }
}
