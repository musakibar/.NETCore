using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    { 
        public UpdateBookModel Model {get; set;}
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbcontext;

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Handle()
        {   
            var book = _dbcontext.Books.SingleOrDefault(x=> x.Id == BookId);

            if(book is null)
                throw new InvalidOperationException("Güncellenecek Kitap Bulunamadı");

            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;            
            _dbcontext.SaveChanges();
            
        }


    }

    public class UpdateBookModel
    {        
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public int GenreId { get; set; }
    }

}