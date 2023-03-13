using Microsoft.QualityTools.Testing.Fakes;

namespace TddBank.Tests
{
    public class OpeningHoursTests
    {

        [Theory]
        [InlineData(2023, 3, 13, 10, 29, false)]//mo
        [InlineData(2023, 3, 13, 10, 30, true)]//mo
        [InlineData(2023, 3, 13, 10, 31, true)] //mo
        [InlineData(2023, 3, 13, 18, 59, true)] //mo
        [InlineData(2023, 3, 13, 19, 00, false)] //mo
        [InlineData(2023, 3, 13, 13, 0, true)] //sa
        [InlineData(2023, 3, 18, 16, 0, false)] //sa
        [InlineData(2023, 3, 18, 13, 0, true)] //sa
        [InlineData(2023, 3, 19, 20, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.Equal(result, oh.IsOpen(dt));
        }

        [Fact]
        public void IsWeekend_Tests()
        {
            var oh = new OpeningHours();

            using (var context = ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 3, 13);//mo
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 3, 14);//di
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 3, 15);//mo
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 3, 16);//do
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 3, 17);//fr
                Assert.False(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 3, 18);//sa
                Assert.True(oh.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2023, 3, 19);//so
                Assert.True(oh.IsWeekend());
            }
        }

        [Fact]
        public void ReadConfigFile_has_more_than_4_b()
        {
            var oh = new OpeningHours();

            using (var context = ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ReadAllLinesString = sr => new[] { "b", "b", "b", "b", "b" };
                Assert.True(oh.ReadConfigFile());
            }
        }
    }
}
