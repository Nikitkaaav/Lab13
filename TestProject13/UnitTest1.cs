using ClassLibraryLab10;
using Laba13;
namespace TestProject13
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void JournalEntryToString()
        {
            // Arrange
            JournalEntry entry = new JournalEntry("Collection1", "Update", "UpdatedData");

            // Act
            string result = entry.ToString();

            // Assert
            Assert.AreEqual("Коллекция: Collection1, Тип изменения: Update, Данные: UpdatedData", result);
        }

        [TestMethod]
        public void JournalEntryConstructor()
        {
            // Arrange
            string nameCollection = "Collection1";
            string typeChange = "Add";
            string data = "NewData";

            // Act
            JournalEntry entry = new JournalEntry(nameCollection, typeChange, data);

            // Assert
            Assert.AreEqual(nameCollection, entry.NameCollection);
            Assert.AreEqual(typeChange, entry.TypeChange);
            Assert.AreEqual(data, entry.DataObject);
        }

        [TestMethod]
        public void CollectionHandlerEventArgs_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string typeChange = "добавить";
            object data = 42;
            string nameCollection = "TestCollection";

            // Act
            var eventArgs = new CollectionHandlerEventArgs(typeChange, data, nameCollection);

            // Assert
            Assert.AreEqual(typeChange, eventArgs.TypeChange);
            Assert.AreEqual(data, eventArgs.Data);
            Assert.AreEqual(nameCollection, eventArgs.NameCollection);
        }

        [TestMethod]
        public void AddItem()
        {
            // Arrange
            var collection = new MyObservableCollection<BankCard>("TestCollection");
            var eventRaised = false;

            collection.CollectionCountChanged += (source, args) =>
            {
                eventRaised = true;
            };

            // Act
            collection.Add(42);

            // Assert
            Assert.IsTrue(collection.Contains(42));
            Assert.IsTrue(eventRaised);
        }

    }
}