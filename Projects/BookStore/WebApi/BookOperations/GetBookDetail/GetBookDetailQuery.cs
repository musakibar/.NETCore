using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        public int BookId {get; set;}
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            mapper = _mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbcontext.Books.Where(book=> book.Id == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap Bulunamadı");
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            
            return vm;
        }


    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }

    }

}