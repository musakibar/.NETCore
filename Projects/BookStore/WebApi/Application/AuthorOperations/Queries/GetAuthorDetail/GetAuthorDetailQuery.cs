using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int AuthorId { get; set; }
        public GetAuthorDetailModel Model { get; set; }
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;

        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)        
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAuthorDetailModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.AuthorId == AuthorId);

            if(author is null)
                throw new InvalidOperationException("Yazar Bulunamadı");
            
            GetAuthorDetailModel vm = _mapper.Map<GetAuthorDetailModel>(author);
            return vm;

        }
    }

    public class GetAuthorDetailModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

    }


}