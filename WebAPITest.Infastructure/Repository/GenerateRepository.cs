using WebTest.Domain.Common;
using WebTest.Domain.IRepository;

namespace WebAPITest.Infastructure.Repository
{
    public class GenerateRepository<T> : IGenerateRepositoy<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public GenerateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            _context.Add(entity);
            //await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = _context.Set<T>().ToList();
            return result;
        }

        public async Task<T> GetById(int id)
        {
            var result = _context.Set<T>().Find(id);
            return result;
        }

        public Task<T> GetByStringId(string name)
        {
            throw new NotImplementedException();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
