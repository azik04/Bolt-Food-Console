using Domain.Entity;

namespace DAL.Repositories.Roles
{
    public class RoleRepository : IBaseRepository<Role>
    {
        private readonly ApplicationDbContext _db;
        public RoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Role entity)
        {
            await _db.role.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Role entity)
        {
            _db.role.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Role> GetAll() => _db.role;

        public async Task<Role> Update(Role entity)
        {
            _db.role.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Role> GetByName(string entity)
        {
           return _db.role.SingleOrDefault(x=> x.Name == entity);
           
        }
    }
}
