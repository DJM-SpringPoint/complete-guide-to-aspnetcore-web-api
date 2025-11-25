namespace my_books.Data.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation properties for related Books
        public List<Book> Books { get; set; }
    }
}
