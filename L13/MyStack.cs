using System;
using System.Collections;
using System.Collections.Generic;
using LAB10;

namespace L13
{
    public class MyStack<T> : IEnumerable<T>
        where T : Trial, new()
    {
        class MyCollectionEnumerator<T> : IEnumerator<T>
        where T : Trial, new()
        {
            // Первый элемент стека.
            PointMyStack<T> beg;
            // Текущий элемент стека.
            PointMyStack<T> curent;
            // Свойство, которое возращает текущее значение.
            public T Current
            {
                get { return curent.data; }
            }
            /// <summary>
            /// Конструктор с параметром.
            /// </summary>
            /// <param name="c">Стек.</param>
            public MyCollectionEnumerator(MyStack<T> c)
            {
                // Присваиваем значения первому и текущему элементам.
                // Если коллекция пустая.
                if (c is null)
                {
                    beg = null;
                }
                // Если коллекция не пустая.
                else
                    beg = c.beg;
                curent = null;
            }
            object IEnumerator.Current
            {
                get { return Current; }
            }
            public void Dispose() { }
            /// <summary>
            /// Перемещает перечислитель к следующему элементу коллекции.
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                // Если прошли коллекцию.
                if (curent == null)
                    Reset();
                // Если коллекция не закончилась.
                else
                    // Переходим к следующему значению.
                    curent = curent.next;
                // Перечислитель был успешно перемещен к следующему элементу или достиг конца коллекции.
                return curent != null;
            }
            /// <summary>
            /// Устанавливает перечислитель в его начальное положение.
            /// </summary>
            public void Reset()
            {
                curent = beg;
            }
        }
        // Первый элемент стека.
        public PointMyStack<T> beg = null;
        /// <summary>
        /// Свойство длины списка.
        /// </summary>
        // Свойство, чтобы узнать количество элементов в стеке.
        public int Count
        {
            get
            {
                // Если стек пуст.
                if (beg == null)
                    return 0;
                PointMyStack<T> p = beg;
                // Объявляем переменную, которая отвечает за количество элементов в стеке.
                int count = 0;
                // Проходим по элементам стека.
                while (p != null)
                {
                    // Увеличиваем количество элементов стека.
                    p = p.next;
                    count++;
                } // Проходим по элементам стека.
                return count;
            }
        }
        // Конструктор без параметров.
        public MyStack() { }
        /// <summary>
        /// Конструктор, который создает стек определенной длины. 
        /// </summary>
        /// <param name="size">Длина стека.</param>
        public MyStack(int size)
        {
            // Если длина больше нуля.
            if (size > 0)
            {
                // Создаем первый элемент стека.
                beg = new PointMyStack<T>();
                PointMyStack<T> p = beg;
                // Если в длина стека больше одного.
                for (int i = 1; i < size; i++)
                {
                    // Добавляем новый объект в стек.
                    PointMyStack<T> temp = new PointMyStack<T>();
                    p.next = temp;
                    p = temp;
                }
            }
        }
        /// <summary>
        /// Конструктор, который создает коллекцию с теми же объектами и той же длины, что в параметре. Клонирование.
        /// </summary>
        /// <param name="col">Клонируемая коллекция.</param>
        public MyStack(MyStack<T> col)
        {
            // Получаем длины клонируемой коллекции.
            int size = col.Count;
            // Если коллекция не пустая.
            if (size > 0)
            {
                // Клонируем первый элемент коллекции.
                beg = new PointMyStack<T>((T)col.beg.data.Clone());
                PointMyStack<T> old_beg = col.beg;
                PointMyStack<T> p = beg;
                // Если в коллекции больше одного объекта, клонируем их.
                for (int i = 1; i < size; i++)
                {
                    // Клонируем объект коллекции
                    PointMyStack<T> temp = new PointMyStack<T>((T)old_beg.next.data.Clone());
                    p.next = temp;
                    p = temp;
                    // Переходим к следующему объекту. 
                    old_beg = old_beg.next;
                }
            }
        }
        /// <summary>
        /// Удалить элемент из стека.
        /// </summary>
        /// <returns></returns>
        public virtual T Pop()
        {
            // Если стек пуст.
            if (beg == null)
                return null;
            // Последний элемент стека. Элемент, который удаляем.
            T deletedItem = new T();
            // Если стек состоит лишь из одного элемента.
            if (beg.next is null)
            {
                // Удаляем первый элемент и возвращаем его.
                deletedItem = beg.data;
                beg = null;
                return deletedItem;
            }
            PointMyStack<T> p = beg;
            // Проходим по элементам стека.
            while (p.next.next != null)
            {
                // Переходим к следующему элементу стека.
                p = p.next;
            }
            // Удаляем последний элемент и возвращаем его.
            deletedItem = p.next.data;
            p.next = null;
            return deletedItem;
        }
        /// <summary>
        /// Поиск элемента в стеке.
        /// </summary>
        /// <param name="item">Искомый элемент.</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            // Если стек пуст.
            if (beg == null)
                return false;
            PointMyStack<T> PointMyStack = new PointMyStack<T>();
            PointMyStack = beg;
            // Проходим по элементам стека.
            while (true)
            {
                // Если элемент равен искомому.
                if ((PointMyStack.data != null) && PointMyStack.data.Equals(item))
                    return true;
                // Если стек закончился.
                if (PointMyStack.next is null)
                    break;
                // Переход к следующему элементу стека.
                PointMyStack = PointMyStack.next;
            }
            // Если не нашли элемент.
            return false;
        }
        /// <summary>
        /// Заполнить стек случайными элементами.
        /// </summary>
        /// <param name="col">Стек, который будем заполнять.</param>
        public static void CreateRandomStack(MyStack<T> col)
        {
            // Считаем длину стека.
            int size = col.Count;
            // Если стек не пустой, то заполняем его случайными значениями.
            if (size > 0)
            {
                // Создаем случайный элемент и заполняем первый элемент стека.
                Trial t = new Trial();
                t.Init();
                col.beg.data = (T)t;
                PointMyStack<T> p = col.beg;
                // Если в стеке больше одного элемента, проходим по стеку и заполняем его случайными значениями.
                for (int i = 1; i < size; i++)
                {
                    // Создаем случайный элемент.
                    PointMyStack<T> temp = new PointMyStack<T>();
                    t = new Trial();
                    t.Init();
                    // Добавляем случаайный элемент в стек.
                    temp.data = (T)t;
                    p.next = temp;
                    p = temp;
                }
            }

        }
        /// <summary>
        /// Глубокое копирование.
        /// </summary>
        /// <returns></returns>
        public MyStack<T> Clone()
        {
            return new MyStack<T>(this);
        }
        /// <summary>
        /// Добавить элемент в стек.
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(T item)
        {
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
        /// <summary>
        /// Удалить стек.
        /// </summary>
        public virtual void Clear()
        {
            beg = null;
        }
        /// <summary>
        /// Поверхностное копирование.
        /// </summary>
        /// <returns></returns>
        public MyStack<T> ShallowCopy()
        {
            return this;
        }
        /// <summary>
        /// Печать стека.
        /// </summary>
        public void Print()
        {
            // Если стек пуст.
            if (beg == null)
            {
                Console.WriteLine("Коллекция пустая!");
                return;
            }
            // Перебираем и печатаем элементы.
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }
        /// <summary>
        ///  Определить, стек пуст или нет.
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return beg == null;
        }
        public virtual IEnumerator<T> GetEnumerator()
        {
            return new MyCollectionEnumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

