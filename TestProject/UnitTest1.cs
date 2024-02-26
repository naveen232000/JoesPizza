using JoesPizza.Migrations;
using JoesPizza.Models;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        private Pizza _pizza;

        [SetUp]
        public void Setup()
        {
            _pizza = new Pizza
            {
                ItemId = 1,
                ItemName = "Margherita Pizza",
                Title = "Margherita Pizza",
                Description = "A classic delight with 100% real mozzarella cheese.",
                Price = 323.99,
                Image = new byte[0]
            };
        }

        [Test]
        public void CanBeCreated()
        {
            Assert.IsNotNull(_pizza);
        }

        [Test]
        public void PropertiesCanBeSet()
        {
            Assert.AreEqual(1, _pizza.ItemId);
            Assert.AreEqual("Margherita Pizza", _pizza.ItemName);
            Assert.AreEqual("Margherita Pizza", _pizza.Title);
            Assert.AreEqual("A classic delight with 100% real mozzarella cheese.", _pizza.Description);
            Assert.AreEqual(323.99, _pizza.Price);
            Assert.AreEqual(new byte[0], _pizza.Image);
        }
    }
    }