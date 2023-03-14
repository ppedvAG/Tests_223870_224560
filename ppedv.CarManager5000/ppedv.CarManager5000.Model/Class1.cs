namespace ppedv.CarManager5000.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string? Color { get; set; }
        public int KW { get; set; }
        public DateTime BuildDate { get; set; }
        public double Weight { get; set; }
    }
}