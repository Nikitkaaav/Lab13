using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba13
{
    // Передача инфы о событии, связанной с изменением коллекции
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string TypeChange { get; }
        public object Data { get; }
        public string NameCollection { get; set; }
        public CollectionHandlerEventArgs(string typeChange, object data, string nameCollection)
        {
            TypeChange = typeChange;
            Data = data;
            NameCollection = nameCollection;
        }
    }
}
