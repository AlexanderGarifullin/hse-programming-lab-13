using System;
using LAB10;

namespace L13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        // Объект, с которым связаны изменения в стеке.
        public Trial item { get; set; }
        // Индекс изменяемого элемента.
        public int index { get; set; }
        // Тип изменений в стеке.
        public string typeChange { get; set; }
        /// <summary>
        /// Конструтор для инициализации.
        /// </summary>
        /// <param name="_typeChange">Тип изменения в стеке.</param>
        /// <param name="_item">Объект, с которым связаны изменения в стеке.</param>
        /// <param name="_index">Индекс изменяемого элемента.</param>
        public CollectionHandlerEventArgs(string _typeChange, Trial _item, int _index = -1)
        {
            item = _item;
            index = _index;
            typeChange = _typeChange;
        }
        /// <summary>
        /// Переопределенный метод Equals.
        /// </summary>
        /// <param name="obj">Объект, с которым сраниваем текущий экземпляр класса.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // Если сравниваем с объектом такого же класса.
            if (obj is CollectionHandlerEventArgs e)
            {
                return item.Equals(e.item) && index.Equals(e.index) && typeChange.Equals(e.typeChange);
            } // Если сравниваем с объектом другого класса.
            return false;
        }
    }
}
