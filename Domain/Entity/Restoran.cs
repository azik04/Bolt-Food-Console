namespace Domain.Entity
{
    public class Restoran
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Food> Food { get; set; }

    }
}
