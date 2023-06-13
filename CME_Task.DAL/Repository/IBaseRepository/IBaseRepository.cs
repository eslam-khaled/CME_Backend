using CME_Task.Common.Enums;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CME_Task.DAL.Repository.IBaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity obj);
        bool AddList(IEnumerable<TEntity> obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity obj);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate);
        Task<Tuple<int, IEnumerable<TEntity>>> GetPages(int pageNumber, int pageSize, string sortingColumn,
        Enum_SortingType sort, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>,
        IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
