namespace ppedv.CarManager5000.Model
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}