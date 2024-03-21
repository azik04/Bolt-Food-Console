using Domain.Entity;

namespace DAL.Repositories.Foods
{
    public class FoodRepository : IBaseRepository<Food>
    {
        private readonly ApplicationDbContext _db;
        public FoodRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Food entity)
        {
            await _db.food.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Food entity)
        {
            _db.food.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Food> GetAll() => _db.food;

        public async Task<Food> Update(Food entity)
        {
            _db.food.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
