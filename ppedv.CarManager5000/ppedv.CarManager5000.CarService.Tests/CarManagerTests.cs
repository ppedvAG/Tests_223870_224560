using Moq;
using ppedv.CarManager5000.Model;
using ppedv.CarManager5000.Model.Contracts;

namespace ppedv.CarManager5000.CarService.Tests
{
    public class CarManagerTests
    {
        [Fact]
        public void GetManufacturerWithFastestCars_2_manufacturer_result_is_BMW()
        {
            var cm = new CarManager(new TestRepo());

            var result = cm.GetManufacturerWithFastestCars();

            Assert.Equal("BMW", result.Name);
        }

        [Fact]
        public void GetManufacturerWithFastestCars_2_manufacturer_result_is_BMW_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Manufacturer>()).Returns(() =>
            {
                var man1 = new Manufacturer() { Name = "Audi" };
                man1.Cars.Add(new Car() { KW = 60 });
                var man2 = new Manufacturer() { Name = "BMW" };
                man2.Cars.Add(new Car() { KW = 80 });

                return new[] { man1, man2 };
            });
            var cm = new CarManager(mock.Object);

            var result = cm.GetManufacturerWithFastestCars();

            Assert.Equal("BMW", result.Name);
        }

        [Fact]
        public void GetManufacturerWithFastestCars_3_manufacturer_same_KW_result_is_BMW_because_of_build_date()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Manufacturer>()).Returns(() =>
            {
                var man1 = new Manufacturer() { Name = "Audi" };
                man1.Cars.Add(new Car() { KW = 60, BuildDate = DateTime.Now.AddDays(-5) });
                var man2 = new Manufacturer() { Name = "BMW" };
                man2.Cars.Add(new Car() { KW = 60, BuildDate = DateTime.Now.AddDays(-4) });
                var man3 = new Manufacturer() { Name = "Benz" };
                man3.Cars.Add(new Car() { KW = 60, BuildDate = DateTime.Now.AddDays(-6) });

                return new[] { man1, man2, man3 };
            });
            var cm = new CarManager(mock.Object);

            var result = cm.GetManufacturerWithFastestCars();

            mock.Verify(x => x.Delete(It.IsAny<Manufacturer>()), Times.Never);
            mock.Verify(x => x.GetAll<Manufacturer>(), Times.Once);

            Assert.Equal("BMW", result.Name);
        }
    }

    class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            if (typeof(T) == typeof(Manufacturer))
            {
                var man1 = new Manufacturer() { Name = "Audi" };
                man1.Cars.Add(new Car() { KW = 60 });
                var man2 = new Manufacturer() { Name = "BMW" };
                man2.Cars.Add(new Car() { KW = 80 });

                return new[] { man1, man2 }.Cast<T>();
            }
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}