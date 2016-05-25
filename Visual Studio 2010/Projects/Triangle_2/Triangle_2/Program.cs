using System;
using System.Collections;
namespace Expample
{
    class Program
    {
        static void Main()
        {
            SortedList list = new SortedList(); //создаем коллекцию и добавляем в нее элементы
            list.Add(1, "Петров");
            list.Add(4, "Сидоров");
            list.Add(3, "Иванов");
            list.Add(2, "Грачев");
            ICollection keys = list.Keys; //получаем коллекцию ключей
            foreach (int key in keys) //выводим на экран пары ключ/значение
            {
                Console.WriteLine("{0} {1}", key, list[key]);
            }
        }
    }
}
Результат работы программы:
1 Петров
2 Грачев
3 Иванов
4 Сидоров