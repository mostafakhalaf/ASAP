using Domain.Entities;

namespace DataAccessLayer.IRepositories
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> SpecialMethod();
    }
}