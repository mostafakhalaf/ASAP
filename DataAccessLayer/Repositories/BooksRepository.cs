using DataAccessLayer.IRepositories;
using Domain.Entities;
using Infrastructure.Database;

namespace DataAccessLayer.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        private readonly ApplicationDbContext _context;

        public BooksRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            List<Book> books = [];
            Span<Book> span = [];
            span.Sort();
        }

        //public BooksRepository(/*ApplicationDbContext context*/) /*: base(context)*/
        //{
        //}

        public IEnumerable<Book> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}