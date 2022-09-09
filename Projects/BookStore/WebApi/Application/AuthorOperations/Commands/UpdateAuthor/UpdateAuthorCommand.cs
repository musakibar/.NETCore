using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _context;        
        public UpdateAuthorCommand(BookStoreDbContext context)        
        {
            _context = context;            
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.AuthorId == AuthorId);

            if(author is null)
                throw new InvalidOperationException("Yazar Bulunamadı");

            author.Name = Model.Name.Trim() != default ? Model.Name : author.Name;
            author.Surname = Model.Surname.Trim() != default ? Model.Surname : author.Surname;
            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;

            _context.SaveChanges();

        }

    }

    public class UpdateAuthorModel
    {        
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

    }

}