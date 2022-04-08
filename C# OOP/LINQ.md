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