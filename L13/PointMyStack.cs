using LAB10;
namespace L13
{
    public class PointMyStack<T>
        where T : Trial, new()
    {
        // Информационное поле. 
        public T data;
        // Поле, хранящие следующее значения.
        public PointMyStack<T> next;
        // Конструктор без параметров.
        public PointMyStack()
        {
            data = default;
            next = null;
        }
        // Конструктор с параметрами.
        public PointMyStack(T inf)
        {
            data = inf;
            next = null;
        }
        /// <summary>
        /// Переопределенный метод Equals.
        /// </summary>
        /// <param name="obj">Объект, с которым сраниваем текущий экземпляр класса.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // Если сравниваем с объектом такого же класса.
            if (obj is PointMyStack<T> t)
            {
                // Объявляем переменную, которая хранит информацию о существовании следующего элемента у текущего экземпляра класса. 
                bool nextIsExist = true;
                // Если нет следующего элемента у экземпляра класса. 
                if (next is null)
                {
                    //  Если есть следующий элемент у сравниваемого экземпляра класса.
                    if (!(t.next is null))
                        return false;
                    // Фиксируем, что нет следующего элемента.
                    nextIsExist = false;
                }
                // Если нет следующего элемента у сравниваемого объекта. 
                if (t.next is null)
                {
                    // Если есть следующий элемент у сравниваемого экземпляра класса.
                    if (!(next is null))
                        return false;
                }
                // Если нет данных в одном из объектов.
                if ((data is null) ^ (t.data is null))
                    return false;
                // Если элементы не ссылются на предыдущее и следующее значения. 
                if (!nextIsExist)
                {
                    // Если нет данных в обоих объектах. 
                    if (data is null)
                        return true;
                    // Если есть данные об объекте.
                    return data.Equals(t.data);
                }
                // Если нет данных о текущем объекте. 
                if (data is null)
                {
                    // Если нет данных в одном из объектов. 
                    if ((next.data is null) ^ (t.next.data is null))
                        return false;
                    // Если нет следующего объекта. 
                    if (next.data is null)
                        return true;
                    // Если есть данные о следующем объекте.
                    return next.data.Equals(t.next.data);
                }
                // Если есть информация обо всех обхектах. 
                return data.Equals(t.data) & next.data.Equals(t.next.data);
            } // Если сравниваем с объектом другого класса.
            return false;
        }
        /// <summary>
        /// Возвращает строковый вид информационного поля. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return data.ToString();
        }
    }
}
