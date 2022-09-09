using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {   
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbcontext.Books.Include(x=> x.Genre).Include(x=> x.Author).OrderBy(x=> x.Id);

            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);            
            return vm;

        }
    }

    public class BooksViewModel
    {
        public string Title {get; set;}
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }

    }

}