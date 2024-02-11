using System;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}