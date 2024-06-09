using ClassLibraryLab10;

namespace Laba13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyObservableCollection<BankCard> collection1 = new MyObservableCollection<BankCard>("Коллекция 1");
            MyObservableCollection<BankCard> collection2 = new MyObservableCollection<BankCard>("Коллекция 2");

            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            collection1.CollectionCountChanged += journal1.CollectionCountChanged;
            collection2.CollectionReferenceChanged += journal1.CollectionReferenceChanged;

            collection1.CollectionReferenceChanged += journal2.CollectionReferenceChanged;
            collection2.CollectionReferenceChanged += journal2.CollectionReferenceChanged;

        }
        
    }
    
}