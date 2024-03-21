using Domain.Entity;

namespace DAL.Repositories.Restorans
{
    public class RestoranRepository : IBaseRepository<Restoran>
    {
        private readonly ApplicationDbContext _db;
        public RestoranRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Restoran entity)
        {
            await _db.restoran.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Restoran entity)
        {
            _db.restoran.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Restoran> GetAll() => _db.restoran;

        public async Task<Restoran> Update(Restoran entity)
        {
            _db.restoran.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
