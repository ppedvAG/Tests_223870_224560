using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.CarManager5000.CarService.UI.Desktop.Tests.Views
{
    public class CarViewTests : IDisposable
    {
        FlaUI.Core.Application app;

        public CarViewTests()
        {
            string appPath = "ppedv.CarManager5000.CarService.UI.Desktop.exe";
            app = FlaUI.Core.Application.Launch(appPath);
        }

        public void Dispose()
        {
            app?.Close();
        }

        [Fact]
        [Trait("", "UITest")]
        public void On_startup_the_gild_should_be_filled_with_cars()
        {
            using (var automation = new UIA3Automation())
            {
                var win = app.GetMainWindow(automation);

                var grid = win.FindFirstDescendant(x => x.ByAutomationId("carGrid"))
                              .AsDataGridView();

                grid.Rows.Length.Should().BeGreaterThan(0);
            }
        }
    }
}
