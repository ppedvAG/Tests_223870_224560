using ppedv.CarManager5000.CarService.UI.Desktop.ViewModels;
using FluentAssertions;
using Moq;
using ppedv.CarManager5000.Model.Contracts;
using ppedv.CarManager5000.Model;

namespace ppedv.CarManager5000.CarService.UI.Desktop.Tests.ViewModels
{
    public class CarViewModelTests
    {
        [Fact]
        public void CarList_should_be_loaded_at_launch()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Car>()).Returns(() =>
            {
                var car1 = new Car();
                return new[] { car1 };
            });
            var vm = new CarViewModel(mock.Object);

            vm.Cars.Should().NotBeEmpty();
            mock.Verify(x => x.GetAll<Car>(), Times.Once);
        }
    }
}