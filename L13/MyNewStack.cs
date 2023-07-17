using System;
using System.Collections.Generic;
using LAB10;

namespace L13
{
    public delegate void StackHandler(object source, CollectionHandlerEventArgs e);
    public class MyNewStack<T> : MyStack<T>
        where T : Trial, new()
    {
        // Сообщение для события при добавлении элемента. 
        static string ADD_COUNT_CHANGED = "Добавили элемент!";
        // Сообщение для события при удаления элемента. 
        static string DELETE_COUNT_CHANGED = "Удалили элемент!";
        // Сообщение для события при изменении элемента. 
        static string REFERENCE_CHANGED = "Изменили элемент!";
        // Свойство, чтобы узнать количество элементов в стеке.
        public int Length
        {
            get
            {
                return Count;
            }
        }
        // Название коллекции.
        public string Name { get; set; }

        // Индексатор для доступа к элементу с заданным номером.
        public T this[int index]
        {
            get
            {
                // Проверяем: есть ли элемент под полученным индексом. 
                if (index >= 0 && index < Length)
                {
                    // Переменная, которая хранит индекс текущего элемента.
                    int tek = 0;
                    // Переменная для перебора элементов коллекции.
                    PointMyStack<T> p = new PointMyStack<T>();
                    // Получаем первый элемент коллекции.
                    p = beg;
                    // Пока не дойдем до нужного элемента. 
                    while (tek != index)
                    {
                        // Переходим к следующему элементу стека.
                        tek++;
                        p = p.next;
                    }// Пока не дойдем до нужного элемента. 
                    // Возвращаем элемент стека.
                    return p.data;
                }
                // Если нет элемента под поулченным индексом.
                else
                    // Возвращаем элемент, созданный конструктором без параметров.
                    return new T();
            }
            set
            {
                // Проверяем: есть ли элемент под полученным индексом. 
                if (index >= 0 && index < Length)
                {
                    // Переменная, которая хранит индекс текущего элемента.
                    int tek = 0;
                    // Переменная для перебора элементов коллекции.
                    PointMyStack<T> p = new PointMyStack<T>();
                    // Получаем первый элемент коллекции.
                    p = beg;
                    // Пока не дойдем до нужного элемента. 
                    while (tek != index)
                    {
                        // Переходим к следующему элементу стека.
                        tek++;
                        p = p.next;
                    } // Пока не дойдем до нужного элемента. 
                    // Изменяем элемент стека.
                    p.data = value;
                    // Вызываем событие. 
                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(REFERENCE_CHANGED, value, tek));
                }
                // Если нет элемента под поулченным индексом.
                else
                {
                    // Сообщаем, что нет элемента с полученным индексом. 
                    Console.WriteLine("В стеке нет элемента с таким индексом!");
                }
            }
        }
        // События при ужалении/добавлении элемента стека.
        public event StackHandler CollectionCountChanged;
        // Событие при изменении ссылки в коллекции.
        public event StackHandler CollectionReferenceChanged;


        /// <summary>
        /// Конструктор, который создает пустую коллекцию.
        /// </summary>
        /// <param name="name">Имя коллекции.</param>
        public MyNewStack(string name) : base()
        {
            Name = name;
        }
        /// <summary>
        /// Конструктор, который создает коллекцию определенной длины.
        /// </summary>
        /// <param name="name">Имя коллекции.</param>
        /// <param name="size">Длина коллекции.</param>
        public MyNewStack(string name, int size) : base(size)
        {
            Name = name;
        }
        // Заполнить коллекцию случайными элементами.
        public void FillStackWithRandomElements()
        {
            // Считаем длину стека.
            int size = Length;
            // Если стек не пустой, то заполняем его случайными значениями.
            if (size > 0)
            {
                // Создаем случайный элемент и заполняем первый элемент стека.
                Trial t = new Trial();
                t.Init();
                beg.data = (T)t;
                PointMyStack<T> p = beg;
                // Если в стеке больше одного элемента, проходим по стеку и заполняем его случайными значениями.
                for (int i = 1; i < size; i++)
                {
                    // Создаем случайный элемент.
                    PointMyStack<T> temp = new PointMyStack<T>();
                    t = new Trial();
                    t.Init();
                    // Добавляем случаайный элемент в стек.
                    temp.data = (T)t;
                    // Переходим к следующему элементу стека.
                    p.next = temp;
                    p = temp;
                }
            }
        }
        // Добавление элемента в коллекцию.
        public override void Add(T item)
        {
            // Добавлеяем элемент в стек.
            base.Add(item);
            // Вызываем событие.
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(ADD_COUNT_CHANGED, item));
        }
        // Добавление случайного элемента в коллекцию.
        public void AddDefault()
        {
            // Создаем случаный элемент, который будем добавлять в коллекцию.
            T item = new T();
            item.Init();
            // Вызываем событие. 
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(ADD_COUNT_CHANGED, item));
            // Получаем первый элемент стека.
            PointMyStack<T> p = beg;
            // Если стек пуст.
            if (p == null)
            {
                // Создаем новый стек с одним добавляемым объектом.
                beg = new PointMyStack<T>(item);
                return;
            }
            // Проходим по стеку, ищем последний элемент.
            while (p.next != null)
            {
                // Переход к следующему элементу списка.
                p = p.next;
            }
            // Добавляем новый элемент в конец стека.
            PointMyStack<T> newItem = new PointMyStack<T>(item);
            p.next = newItem;
        }


        // Удаление элемента из коллекции.
        public override T Pop()
        {
            // Удаляем последний объект стека.
            T deletedItem = base.Pop();
            // Если удалили элемент стека.
            if (deletedItem != null)
                // Вызываем событие.
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(DELETE_COUNT_CHANGED, deletedItem));
            // Возвращаем удаленный элемент.
            return deletedItem;
        }
        // Очистка коллекции.
        public override void Clear()
        {
            base.Clear();
        }
        // Итератор для доступа к элементам коллекции.
        public override IEnumerator<T> GetEnumerator()
        {
            return base.GetEnumerator();
        }
        // Удаление элемента по номеру, если нет элемента с номером, метод возращает false.
        public bool Remove(int j)
        {
            // Проверяем: есть ли элемент с полученным номером. 
            if (j >= 1 && j <= Length)
            {
                // Если удаляем первый элемент стека.
                if (j == 1)
                {
                    // Вызываем событие.
                    OnCollectionCountChanged(this, new CollectionHandlerEventArgs(DELETE_COUNT_CHANGED, beg.data));
                    // Удаляем первый объект стека.
                    beg = beg.next;
                    return true;
                }
                // Переменная, которая хранит номер текущего элемента.
                int tek = 2;
                // Переменная, которая хранит предыдущее значение.
                PointMyStack<T> pPred = beg;
                // Переменная, которая хранит текущее значение.
                PointMyStack<T> pCurrent = beg.next;
                // Пока не дошли до удаляемого элемента.
                while (tek != j)
                {
                    // Переходим к следующему элементу стека.
                    tek++;
                    pPred = pCurrent;
                    pCurrent = pCurrent.next;
                } // Пока не дошли до удаляемого элемента.
                // Удаляем элемент под полученным номером.
                pPred.next = pCurrent.next;
                // Вызываем событие. 
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(DELETE_COUNT_CHANGED, pCurrent.data));
                return true;
            }
            // Если нет элемента с полученным номером.
            return false;
        }
        /// <summary>
        /// Метод, который вызывает событие при удалении/добавлении элементов.
        /// </summary>
        /// <param name="source">Объект, генерирующий событие.</param>
        /// <param name="e">Дополнительная информация, необходимая обработчику события</param>
        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs e)
        {
            CollectionCountChanged?.Invoke(source, e);
        }
        /// <summary>
        /// Метод, который вызывает событие при изменении элементов коллекции.
        /// </summary>
        /// <param name="source">Объект, генерирующий событие.</param>
        /// <param name="e">Дополнительная информация, необходимая обработчику события.</param>
        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs e)
        {
            CollectionReferenceChanged?.Invoke(source, e);
        }
        /// <summary>
        /// Переопределенный метод Equals.
        /// </summary>
        /// <param name="obj">Объект, с которым сраниваем текущий экземпляр класса.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // Если сравниваем с объектом такого же класса.
            if (obj is MyStack<T> stack)
            {
                // Если один из стеков существует, а другой - нет.
                if ((beg is null) ^ (stack.beg is null))
                    return false;
                // Если стеки пустые.
                if (beg is null)
                    return true;
                // Получаем первые элементы стеков. 
                PointMyStack<T> p1 = beg;
                PointMyStack<T> p2 = stack.beg;
                // Перебираем элементы стека.
                while (true)
                {
                    // Если элементы стека не равны.
                    if (!p1.Equals(p2))
                        return false;
                    // Если стек закончился.
                    if (p1.next is null)
                        break;
                    // Переход к следующим значениям стеков.
                    p1 = p1.next;
                    p2 = p2.next;
                } // Перебираем элементы стека.
                // Если стеки равны.
                return true;
            } // Если сравниваем с объектом другого класса.
            return false;
        }

    }
}
