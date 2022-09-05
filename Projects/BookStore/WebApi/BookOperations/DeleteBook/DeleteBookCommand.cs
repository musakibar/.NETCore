using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbcontext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)        
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x=> x.Id == BookId);

            if(book is null)
                throw new InvalidOperationException("Silinecek Kitap Bulunamadı");

            _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();
            
        }
    }

}