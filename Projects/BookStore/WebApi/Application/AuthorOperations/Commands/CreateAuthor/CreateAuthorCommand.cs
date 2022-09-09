
using WebApi.DBOperations;
using AutoMapper;
using WebApi.Entities;
using WebApi.Common;
using System.Collections.Generic;


namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _dbcontext.Authors.SingleOrDefault(x=> x.Name == Model.Name && x.Surname == Model.Surname);

            if(author is not null)
                throw new InvalidOperationException("Yazar zaten mevcut");

            author = _mapper.Map<Author>(Model);

            _dbcontext.Authors.Add(author);
            _dbcontext.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        
    }
}