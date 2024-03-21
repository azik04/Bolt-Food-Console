using Domain.Entity;

namespace DAL.Repositories.Orders
{
    public class OrderRepository : IBaseRepository<Order>
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Order entity)
        {
            await _db.order.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Order entity)
        {
            _db.order.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Order> GetAll() => _db.order;

        public async Task<Order> Update(Order entity)
        {
            _db.order.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
