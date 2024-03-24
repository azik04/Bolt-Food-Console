using Domain.Entity;

namespace DAL.Repositories.Users
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(User entity)
        {
            await _db.user.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            _db.user.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<User> GetAll() => _db.user;

        public async Task<User> Update(User entity)
        {
            _db.user.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
