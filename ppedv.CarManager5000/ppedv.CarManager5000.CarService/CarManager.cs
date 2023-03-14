using ppedv.CarManager5000.Model;
using ppedv.CarManager5000.Model.Contracts;

namespace ppedv.CarManager5000.CarService
{
    public class CarManager
    {
        private readonly IRepository _repository;

        public CarManager(IRepository repository)
        {
            _repository = repository;
        }

        public Manufacturer? GetManufacturerWithFastestCars()
        {
            return _repository.GetAll<Manufacturer>()
                              .OrderByDescending(x => x.Cars.Sum(y => y.KW))
                              .ThenByDescending(x => x.Cars.Average(x => x.BuildDate.Ticks))
                              .FirstOrDefault();
        }
    }
}