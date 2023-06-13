

using CME_Task.DAL.DBContext;
using CME_Task.DAL.Models;
using CME_Task.DAL.Repository.IBaseRepository;

namespace CME_Task.DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        //AppDbContext Context { get; }

        Task<int> SaveChangesAsync();

        IBaseRepository<Customer> Customer { get; set; }
        IBaseRepository<Reservation> Reservation { get; set; }
        IBaseRepository<Room> Room { get; set; }
    }
}
