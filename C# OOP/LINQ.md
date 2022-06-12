# LINQ - Language Integrated Query

Программный интерфейс
 позволяющий обращаться к различным данным, используя один и тот же снтаксис.

Порядок создания запроса:
1) Создать описание запроса
2) Выполнить запрос

## Выборка чисел

```
using System.Linq;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Создать запрос для выборки положительных чисел из массива

            // 1. Источник данных
            int[] nums = new int[] {1, -2, 3, 0 -4 ,5};

            // 2. Описание запроса
            var posNums =       // Параметр запроса
            from n in nums      // начало запроса
            where n > 0         // требование к отбору
            select n;           // предложение выбора
            Console.WriteLine("Положительные величины: ");

            // 3. Выполнение запроса
            foreach (var i in posNums)
                Console.Write($"{i} ");
            
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
```

<br>

# Многократное выполнение запросов
```
using System.Linq;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Создать запрос для выборки положительных чисел из массива

            // 1. Источник данных
            int[] nums = new int[] {-4, -3, -2, 1, 0, 1, 2, 3, 4};

            // 2. Описание запроса
            var posNums =       // Параметр запроса
            from n in nums      // начало запроса
            where n % 2 == 0        // требование к отбору
            select n;           // предложение выбора
            Console.WriteLine("Четные величины: ");

            // 3. Выполнение запроса
            foreach (var i in posNums)
                Console.Write($"{i} ");
            
            Console.WriteLine();
            
            // Внести изменения в массив nums
            nums[1] = 8;
            Console.WriteLine("\nЗапрос после изменения массива: ")ж

            // 4. Повторное выполнение запроса
               foreach (var i in posNums)
                Console.Write($"{i} ");
        }
    }
}
```
<br>

# Отбор запрашиваемых значений с помощью нескольких операторов Where
```
using System.Linq;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            // Создать запрос для выборки положительных чисел из массива < 10

            // 1. Источник данных
            int[] nums = new int[] {1, -2, 3, -3, 0, -8, 12, 19, 6, 9, 10};

            // 2. Описание запроса
            var posNums =       // Параметр запроса
            from n in nums      // начало запроса
            where n % 2 == 0        // требование к отбору
            where n < 10
            select n;           // предложение выбора
            Console.WriteLine("Результат запроса: ");

            // 3. Выполнение запроса
            foreach (var i in posNums)
                Console.Write($"{i} ");
            
            Console.WriteLine();
            
            // Внести изменения в массив nums
            nums[1] = 8;
            Console.WriteLine("\nЗапрос после изменения массива: ")ж

            // 4. Повторное выполнение запроса
               foreach (var i in posNums)
                Console.Write($"{i} ");
        }
    }
}
```

<br>

# Выборка текстоых данных

Поиск Интернет-адресов, заканчивающихся на .net

```
class Program
    {
        static void Main()
        {

            // 1. Источник данных
            int[] strs new int[] {".com", "A.com", ".net", "B.net", "net.test", "C.net", ".network", "D.ru"};

            // 2. Описание запроса
            var netAddrs =       
            from addr in strs     
            where addr.Length > 4 && addr.EndsWith(".net")
            select n;           
            Console.WriteLine("Результат запроса: ");

            // 3. Выполнение запроса
            foreach (var i in netAddrs)
                Console.Write($"{i} ");
            
            Console.WriteLine();
    }
```

<BR>

# Выборка с сортировкой результатов
```
class Program
    {
        static void Main()
        {

            // 1. Источник данных
            int[] nums = new int[] {10, -19, 4, 7, 2, -5, 0};

            // 2. Описание запроса
            var sNums =       
            from n in nums
            orderby n     // ascending - по возрастанию, descending - по убыванию
            select n;           
            Console.WriteLine("Результат запроса: ");

            // 3. Выполнение запроса
            foreach (ште i in sNums)
                Console.Write($"{i} ");
            
            Console.WriteLine();
        }
    }
```
# Выборка с группировкой
```
static void Main()
        {
            string[] websites = { "A.com", "B.net", "C.net", "D.com", "F.org", "H.net", "M.tv", "G.tv" };
            var webAdds =
                from addr in websites
                where addr.LastIndexOf(".") != -1
                group addr by addr.Substring(addr.LastIndexOf("."));

            foreach (var sites in webAdds)
            {
                Console.WriteLine($"Группировка по {sites.Key}");
                foreach (var site in sites)
                {
                    Console.WriteLine($"    {site}");
                }
            }    
            Console.ReadKey();
        }
```

# Вложеннные запросы

```
static void Main()
        {
            // групы, имеющие не менее трех членов
            string[] websites = { "A.com", "B.net", "C.net", "D.com", "F.org", "H.net", "M.tv", "G.tv" };
            var webAdds =
                from addr in websites
                where addr.LastIndexOf(".") != -1
                group addr by addr.Substring(addr.LastIndexOf("."))
                into ws // каждая группа будет отождествляться с этой переменной. Ссылку на группу записываем в эту переменную
                where ws.Count() < 3
                select ws;
            Console.WriteLine("Группы, имеющие менее трех членов");
            foreach (var sites in webAdds)
            {
                Console.WriteLine($"Группировка по {sites.Key}");
                foreach (var site in sites)
                {
                    Console.WriteLine($"    {site}");
                }
                Console.WriteLine();
            }    
            Console.ReadKey();
        }
```
# Временная переменная в запросе
```
static void Main()
        {
            // групы, имеющие не менее трех членов
            string[] strs = { "gamme", "alpha", "beta" };
            // Создать запрос на получениеи в отсортированном порядке симолов из строк
            var chrs =
                from str in strs
                let chrArray = str.ToCharArray()
                from ch in chrArray
                orderby ch
                select ch;

            Console.WriteLine("Отдельные символы, отсортированные по порядку    ");
            foreach (char c in chrs)
                Console.Write($"{c} ");
            Console.ReadKey();
        }
```

Оператор let может также использоваться для хранения неперечислимого зачения
Доработка ранее рассмотренного примера

Запрос для группировки адресов веб сайтов

```
static void Main()
        {
            // групы, имеющие не менее трех членов
            string[] websites = { "A.com", "B.net", "C.net", "D.com", "F.org", "H.net", "M.tv", "G.tv" };
            var webAdds =
                from addr in websites
                let idx = addr.LastIndexOf(".")
                where idx != -1
                group addr by addr.Substring(addr.LastIndexOf("."))
                into ws // каждая группа будет отождествляться с этой переменной. Ссылку на группу записываем в эту переменную
                where ws.Count() < 35
                select ws;
            Console.WriteLine("Группы, имеющие менее трех членов");
            foreach (var sites in webAdds)
            {
                Console.WriteLine($"Группировка по {sites.Key}");
                foreach (var site in sites)
                {
                    Console.WriteLine($"    {site}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
```

# Объединение двух последовательностей
Оператор join, выступающий в роли фильтра, которые имеют общее значение

Класс, связывающий наименование товара с его номеромм
```
class Item
    {
        public string Name { get; set; }
        public int ItemNumber { get; set; }
        public Item(string n, int inum)
        {
            Name = n;
            ItemNumber = inum;
        }
    }
    class InStockStatus // Связывает номер товара с наличием на сайте
    {
        public int ItemNumber { get; set; }
        public bool InStock { get; set; }
        public InStockStatus(int n, bool b)
        {
            ItemNumber = n;
            InStock = b;
        }
    }
    class Temp
    {
        public string Name { get; set; }
        public bool InStock { get; set; }

        public Temp(string n, bool b)
        {
            Name = n;
            InStock = b;
        }
    }

    class Program
    {
        static void Main()
        {
            Item[] items =
            {
                new Item("Кусачки", 1241),
                new Item("Тиски", 7895),
                new Item("Пила", 64111),
            };
            InStockStatus[] statusList =
            {
                new InStockStatus(1241, false),
                new InStockStatus(7895, true),
                new InStockStatus(64111, true),
            };
            var InStockList =
                from item in items
                join entry in statusList
                on item.ItemNumber equals entry.ItemNumber
                select new Temp(item.Name, entry.InStock);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Товар\tНаличие");
            foreach (Temp t in InStockList)
            {
                Console.WriteLine($"{t.Name}\t{t.InStock}");
            }
            Console.ReadKey();
        }
    }
}
```