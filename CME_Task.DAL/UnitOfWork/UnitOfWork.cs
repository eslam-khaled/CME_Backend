using CME_Task.DAL.DBContext;
using CME_Task.DAL.Models;
using CME_Task.DAL.Repository.BaseRepository;
using CME_Task.DAL.Repository.IBaseRepository;
using Microsoft.EntityFrameworkCore;

namespace CME_Task.DAL.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AppDbContext _context;


        public IBaseRepository<Customer> Customer { get; set; }
        public IBaseRepository<Reservation> Reservation { get; set; }
        public IBaseRepository<Room> Room { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Customer = new BaseRepository<Customer>(_context);
            Reservation = new BaseRepository<Reservation>(_context);
            Room = new BaseRepository<Room>(_context);
        }


        #region Unit of work methods

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
