using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba13
{
    // Отслеживание изменений в коллекции
    public class Journal
    {
        private List<JournalEntry> entries; // Поле для хранения записей журнала
                
        public List<JournalEntry> JournalEntries { get { return entries; } }

        public Journal()
        {
            entries = new List<JournalEntry>(); 
        }

        // Метод для обработки изменений количества элементов в коллекции
        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs e)
        {
            // Создание новой записи журнала и добавление её в список
            JournalEntry je = new JournalEntry(e.NameCollection, e.TypeChange, e.Data.ToString());
            entries.Add(je);
        }

        // Метод для обработки изменений ссылок в коллекции
        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs e)
        {
            // Создание новой записи журнала и т. д.
            JournalEntry je = new JournalEntry(e.NameCollection, e.TypeChange, e.Data.ToString());
            entries.Add(je);
        }

        // Метод для вывода всех записей журнала
        public void Show()
        {
            foreach (JournalEntry je in entries)
            {
                Console.WriteLine(je.ToString()); 
            }
        }
    }
}
