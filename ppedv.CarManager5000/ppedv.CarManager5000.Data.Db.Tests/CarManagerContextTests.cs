using ppedv.CarManager5000.Model;

namespace ppedv.CarManager5000.Data.Db.Tests
{
    public class CarManagerContextTests
    {
        [Fact]
        public void Can_create_Db()
        {
            var con = new CarManagerContext();
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_insert_Car()
        {
            var con = new CarManagerContext();
            con.Database.EnsureCreated();
            var car = new Car() { Model = "XYZ", Color = "gelb", KW = 85, Weight = 874.3 };

            con.Add(car);
            int count = con.SaveChanges();

            Assert.Equal(1, count);
        }

        [Fact]
        public void Can_read_Car()
        {
            var car = new Car() { Model = "XYZ", Color = "gelb", KW = 85, Weight = 874.3 };
            using (var con = new CarManagerContext())
            {
                con.Database.EnsureCreated();
                con.Add(car);
                con.SaveChanges();
            }

            using (var con = new CarManagerContext())
            {
                var loadedCar = con.Cars.Find(car.Id);
                Assert.NotNull(loadedCar);
                Assert.Equal(car.Model, loadedCar.Model);
                Assert.Equal(car.Color, loadedCar.Color);
                Assert.Equal(car.KW, loadedCar.KW);
                Assert.Equal(car.Weight, loadedCar.Weight);
            }
        }


    }
}