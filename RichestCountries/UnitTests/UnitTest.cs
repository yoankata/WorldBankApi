using NUnit.Framework;
using RichestCountries.ApiHelpers;

namespace UnitTests
{
    public class UnitTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PingWorldBankApi()
        {
            var jsonString = WorldBankApi.GetJsonFromApi("indicators");

            Assert.NotNull(jsonString, "WorldBank API down or no connection!");
        }
    }
}