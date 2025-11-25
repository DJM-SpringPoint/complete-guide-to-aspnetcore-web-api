using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            var _authorWithBooks = _context.Authors.Where(n => n.Id == authorId).Select(author => new AuthorWithBooksVM()
            {
                FullName = author.FullName,
                BookTitles = author.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _authorWithBooks;
        }

    }
}
