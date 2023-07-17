namespace L13
{
    public class JournalEntry
    {
        // Название коллекции.
        public string name { get; set; }
        // Тип изменения в коллекции.
        public string typeChange { get; set; }
        // Объект, с которым связаны изменения в коллекции.
        public string changedItem { get; set; }
        /// <summary>
        /// Конструтор для инициализации.
        /// </summary>
        /// <param name="_name">Название коллекции.</param>
        /// <param name="_typeChange">Тип изменений.</param>
        /// <param name="_changedItem">Объект, с которым связаны изменения в коллекции.</param>
        public JournalEntry(string _name, string _typeChange, string _changedItem)
        {
            name = _name;
            typeChange = _typeChange;
            changedItem = _changedItem;
        }
        /// <summary>
        /// Переопределенный метод ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Название коллекции = {name}; тип изменения = {typeChange}; объект, с которым связаны изменения в коллекции = {changedItem}";
        }
        /// <summary>
        /// Переопределенный метод Equals.
        /// </summary>
        /// <param name="obj">Объект, с которым сраниваем текущий экземпляр класса.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            // Если сравниваем с объектом такого же класса.
            if (obj is JournalEntry je)
            {
                return name.Equals(je.name) && typeChange.Equals(je.typeChange) && changedItem.Equals(je.changedItem);
            } // Если сравниваем с объектом другого класса.
            return false;
        }
    }
}
