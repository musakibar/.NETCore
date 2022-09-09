using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {

        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.AuthorId == AuthorId);
            var isactive = _context.Books.Where(x=> x.AuthorId == AuthorId);

            if(author is null)
                throw new InvalidOperationException("Yazar Bulunamadı");
            else if(isactive is not null)
                throw new InvalidOperationException("Yazarın yayında olan aktif kitabı var");

            _context.Remove(author);
            _context.SaveChanges();

        }

    }   

}