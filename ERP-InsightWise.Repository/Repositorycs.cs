using ERP_InsightWise.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using ERP_InsightWise.Database;

namespace ERP_InsightWise.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly FIAPDBContext _context;

        private readonly DbSet<T> _dbSet;

        public Repository(FIAPDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.AddAsync(entity);

            _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            if (_dbSet == null)
            {
                throw new InvalidOperationException("DbSet não está inicializado.");
            }

            return _dbSet.ToList();
        }


        public T GetById(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "O ID não pode ser nulo.");
            }

            return _dbSet.Find(id);
        }


        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
