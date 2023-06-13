using CME_Task.Common.Enums;
using CME_Task.DAL.DBContext;
using CME_Task.DAL.Repository.IBaseRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;


namespace CME_Task.DAL.Repository.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext dataContext)
        {
            _context = dataContext;
        }


        public async Task<TEntity> AddAsync(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public bool AddList(IEnumerable<TEntity> obj)
        {
            _context.Set<TEntity>().AddRange(obj);
            _context.SaveChanges();
            return true;
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            var result = await _context.Set<TEntity>().FindAsync(id);
            if (result == null)
            {
                throw new ArgumentException($"The specified ID '{id}' does not exist in the database.", nameof(id));
            }
            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id) ?? throw new ArgumentException("The specified ID does not exist in the database.", nameof(id));
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            _context.Set<TEntity>().Attach(obj);
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task DeleteAsync(int id)
        {
            TEntity entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public virtual async Task<Tuple<int, IEnumerable<TEntity>>> GetPages(int pageNumber, int pageSize, string sortingColumn,
            Enum_SortingType sort, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var result = _context.Set<TEntity>()
                .Where(x => true);

            if (predicate != null) result = result.Where(predicate);

            if (include != null)
                result = include(result);

            if (include != null)
                result = include(result);

            var page = await result.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await result.CountAsync();

            return new Tuple<int, IEnumerable<TEntity>>(count, page);
        }
    }
}
