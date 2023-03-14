using System.Globalization;

namespace ppedv.CarManager5000.Model
{
    public class Car
    {
        public int Id { get; set; }
        public virtual Manufacturer? Manufacturer { get; set; }
        public string Model { get; set; } = string.Empty;
        public string? Color { get; set; }
        public int KW { get; set; }
        public DateTime BuildDate { get; set; }
        public double Weight { get; set; }
    }
}