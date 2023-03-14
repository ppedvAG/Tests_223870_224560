using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ppedv.CarManager5000.Model;
using System.Reflection;

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

            //Assert.True(result);
            result.Should().BeTrue();
        }

        [Fact]
        public void Can_insert_Car()
        {
            var con = new CarManagerContext();
            con.Database.EnsureCreated();
            var car = new Car() { Model = "XYZ", Color = "gelb", KW = 85, Weight = 874.3 };

            con.Add(car);
            int count = con.SaveChanges();

            //Assert.Equal(1, count);
            count.Should().Be(1);
        }

        [Fact]
        public void Can_read_Car()
        {
            var car = new Car() { Model = $"XYZ_{Guid.NewGuid()}", Color = "gelb", KW = 85, Weight = 874.3 };
            using (var con = new CarManagerContext())
            {
                con.Database.EnsureCreated();
                con.Add(car);
                con.SaveChanges();
            }

            using (var con = new CarManagerContext())
            {
                var loadedCar = con.Cars.Find(car.Id);
                loadedCar.Should().NotBeNull();
                loadedCar.Should().BeEquivalentTo(car);
                //Assert.NotNull(loadedCar);
                //Assert.Equal(car.Model, loadedCar.Model);
                //Assert.Equal(car.Color, loadedCar.Color);
                //Assert.Equal(car.KW, loadedCar.KW);
                //Assert.Equal(car.Weight, loadedCar.Weight);
            }
        }

        [Fact]
        public void Can_insert_and_read_Manufacturer()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter("Id"));
            var man = fix.Create<Manufacturer>();

            using (var con = new CarManagerContext())
            {
                con.Database.EnsureCreated();
                con.Add(man);
                con.SaveChanges();
            }

            using (var con = new CarManagerContext())
            {
                var loadedMan = con.Manufacturers.Include(x => x.Cars).FirstOrDefault(x => x.Id == man.Id);
                loadedMan.Should().NotBeNull();
                loadedMan.Should().BeEquivalentTo(man, x => x.IgnoringCyclicReferences());
            }
        }
    }

    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }

}