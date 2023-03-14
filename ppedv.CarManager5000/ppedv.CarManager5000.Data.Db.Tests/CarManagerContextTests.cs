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
    }
}