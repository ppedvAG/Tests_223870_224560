using CommunityToolkit.Mvvm.Input;
using ppedv.CarManager5000.Data.Db;
using ppedv.CarManager5000.Model;
using ppedv.CarManager5000.Model.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ppedv.CarManager5000.CarService.UI.Desktop.ViewModels
{
    public class CarViewModel
    {
        private readonly IRepository repo;

        public CarViewModel() : this(new EfRepository())
        { }

        public CarViewModel(IRepository repo)
        {
            this.repo = repo;

            Cars = new ObservableCollection<Car>(repo.GetAll<Car>());

            SaveCommand = new RelayCommand(() => repo.SaveAll());
            NewCommand = new RelayCommand(UserWantsCreateNewCar);
        }

        private void UserWantsCreateNewCar()
        {
            var newCar = new Car() { BuildDate = DateTime.Now, KW = 100, Model = "NEU", Color = "blau" };
            repo.Add(newCar);
            Cars.Add(newCar);
            SelectedCar = newCar;
        }

        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public ObservableCollection<Car> Cars { get; set; }

        public Car SelectedCar { get; set; }
    }
}
