using System;
using System.Collections.Generic;
using System.Collections;
using LAB10;
namespace L13
{
    public class Journal : IEnumerable
    {
        // Лист, где храним изменения в стеке.
        public List<JournalEntry> journalEntries = new List<JournalEntry>();
        // Конструктор без параметров.
        public Journal() { }
        /// <summary>
        /// Добавляем элемент в историю журнала.
        /// </summary>
        /// <param name="je">Переменная, которая хранит изменения в стеке.</param>
        public void Add(JournalEntry je)
        {
            // Добавляем изменения в историю изменений.
            journalEntries.Add(je);
        }
        // Метод печати, вызываемый событием, при измененеия числа элементов стека. 
        public static void WriteCountChange(object source, CollectionHandlerEventArgs e)
        {
            // Печатаем тип изменения.
            Console.WriteLine(e.typeChange);
            // Печатаем объект, с которым связанны изменения. 
            Console.WriteLine(e.item);
        }
        // Метод печати, вызываемый событием, при измененеия элемента стека. 
        public static void WriteReferenceChange(object source, CollectionHandlerEventArgs e)
        {
            // Печатаем тип изменения.
            Console.WriteLine(e.typeChange);
            // Печатаем номер изменяемого элемента.
            Console.WriteLine("Номер изменяемого элемента: " + (e.index + 1));
            // Печатаем объект, с которым связанны изменения. 
            Console.WriteLine("Изменили значение на:");
            Console.WriteLine(e.item);
        }
        // Метод добавления изменений в журнал изменений, вызываемый событием (изменения числа элементов стека).
        public void CollectionCountChanged(object source, CollectionHandlerEventArgs e)
        {
            JournalEntry je = new JournalEntry(((MyNewStack<Trial>)source).Name, e.typeChange, e.item.ToString());
            journalEntries.Add(je);
        }
        // Метод добавления изменений в журнал изменений, вызываемый событием (изменения элемента стека).
        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs e)
        {
            JournalEntry je = new JournalEntry(((MyNewStack<Trial>)source).Name, e.typeChange, e.item.ToString());
            journalEntries.Add(je);
        }
        // Перечисление журнала.
        public IEnumerator GetEnumerator()
        {
            foreach (var item in journalEntries)
            {
                // Если элемент не пустой. 
                if (item != null)
                {
                    // Возвращаем элемент. 
                    yield return item;
                }
            }
        }
        /// <summary>
        /// Переопределенный метод Equals.
        /// </summary>
        /// <param name="obj">Объект, с которым сраниваем текущий экземпляр класса.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // Если сравниваем с объектом такого же класса.
            if (obj is Journal journal)
            {
                // Если журналы хранят разное количество изменений.
                if (journalEntries.Count != journal.journalEntries.Count)
                    return false;
                // Получаем первое изменение в текущем журнале изменений.
                int i = 0;
                // Проходим по изменениям в журнале изменений.
                foreach (var item in journal)
                {
                    // Сравниваем изменения в журналах изменений. 
                    if (item.Equals(journalEntries[i]) == false)
                        return false;
                    // Переходим к следующему изменению в текущем журнале изменений.
                    i++;
                }// Проходим по изменениям в журнале изменений.
                return true;
            } // Если сравниваем с объектом другого класса.
            return false;
        }
    }
}
