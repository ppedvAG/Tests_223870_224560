using ppedv.CarManager5000.Model.Contracts;

namespace ppedv.CarManager5000.Data.Db
{
    public class EfRepository : IRepository
    {
        CarManagerContext _context = new CarManagerContext();

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void SaveAll()
        {
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
