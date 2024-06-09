using System;
using Lab12._4;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLab10;

namespace Laba13
{
    // Отслеживание изменений в коллекции
    public class MyObservableCollection<T> : MyCollection <T> where T : ICloneable, IInit, new()
    {
        public string Name { get; }

        public MyObservableCollection(string name)
        {
            Name = name;
        }

        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args); // Делегат для обработчиков событий
        public event CollectionHandler CollectionCountChanged; // Событие изменения количества элементов в коллекции
        public event CollectionHandler CollectionReferenceChanged; // Событие изменения ссылок в коллекции

        // Изменение количества элементов
        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }

        // Изменение ссылок
        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(source, args);
        }

        // Добаление базового класса
        public override void Add(T data)
        {
            base.Add(data);

            OnCollectionCountChanged(this, new CollectionHandlerEventArgs("добавить", data, Name));
        }

        // Удаление из базового класса
        public override bool Remove(T data)
        {
            bool check = base.Remove(data);
            if (check)
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs("удалить", data, Name));
            return check;
        }


        public T this[T key]
        {
            get => base[key]; // Получение элемента по ключу
            set
            {
                if (Contains(key))
                {
                    base.Remove(key); // Удаление старого элемента
                    base.Add(value); // Добавление нового элемента

                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs("изменено", value, Name));
                }
            }
        }
    }
}
