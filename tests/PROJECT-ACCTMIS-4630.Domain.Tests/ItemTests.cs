using PROJECT_ACCTMIS_4630.Domain.Catalog;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PROJECT_ACCTMIS_4630.Domain.Tests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void Can_Create_New_Item()
        {
            var item = new Item("Shirt", "A blue shirt", "Nike", 29.99m);

            Assert.AreEqual("Shirt", item.Name);
            Assert.AreEqual("A blue shirt", item.Description);
            Assert.AreEqual("Nike", item.Brand);
            Assert.AreEqual(29.99m, item.Price);
        }

        [TestMethod]
        public void New_Item_Has_Empty_Ratings_List()
        {
            var item = new Item("Shirt", "A blue shirt", "Nike", 29.99m);

            Assert.IsNotNull(item.Ratings);
            Assert.AreEqual(0, item.Ratings.Count);
        }

        [TestMethod]
        public void Cannot_Create_Item_With_Null_Name()
        {
            try
            {
                var item = new Item(null, "A blue shirt", "Nike", 29.99m);
                Assert.Fail("Expected ArgumentNullException was not thrown.");
            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void Cannot_Create_Item_With_Empty_Name()
        {
            try
            {
                var item = new Item("", "A blue shirt", "Nike", 29.99m);
                Assert.Fail("Expected ArgumentNullException was not thrown.");
            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void Cannot_Create_Item_With_Null_Description()
        {
            try
            {
                var item = new Item("Shirt", null, "Nike", 29.99m);
                Assert.Fail("Expected ArgumentNullException was not thrown.");
            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void Cannot_Create_Item_With_Null_Brand()
        {
            try
            {
                var item = new Item("Shirt", "A blue shirt", null, 29.99m);
                Assert.Fail("Expected ArgumentNullException was not thrown.");
            }
            catch (ArgumentNullException) { }
        }

        [TestMethod]
        public void Cannot_Create_Item_With_Negative_Price()
        {
            try
            {
                var item = new Item("Shirt", "A blue shirt", "Nike", -1.00m);
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException) { }
        }

        [TestMethod]
        public void Can_AddRating_To_Item()
        {
            var item = new Item("Shirt", "A blue shirt", "Nike", 29.99m);
            var rating = new Rating(5, "Mike", "Great fit!");

            item.AddRating(rating);

            Assert.AreEqual(1, item.Ratings.Count);
        }

        [TestMethod]
        public void AddRating_Stores_Correct_Rating()
        {
            var item = new Item("Shirt", "A blue shirt", "Nike", 29.99m);
            var rating = new Rating(4, "Jane", "Very comfortable.");

            item.AddRating(rating);

            Assert.AreEqual(4, item.Ratings[0].Stars);
            Assert.AreEqual("Jane", item.Ratings[0].UserName);
            Assert.AreEqual("Very comfortable.", item.Ratings[0].Review);
        }

        [TestMethod]
        public void Can_Add_Multiple_Ratings_To_Item()
        {
            var item = new Item("Shirt", "A blue shirt", "Nike", 29.99m);

            item.AddRating(new Rating(5, "Mike", "Great fit!"));
            item.AddRating(new Rating(3, "Sara", "It's okay."));
            item.AddRating(new Rating(4, "Tom", "Pretty good."));

            Assert.AreEqual(3, item.Ratings.Count);
        }
    }
}
