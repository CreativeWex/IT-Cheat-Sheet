# Анонимные типы

Позволяют создать объект с некоторым набором свойств без определения класса.
Анонимный типопредеяется с помощью ключевого слова `var` и инииализватора объекта:

// user - объект анонимного типа с свйоствами Name и Age
Пример
```
static void Main(string[] args)
        {
            // user - объект анонимного типа с свйоствами Name и Age
            var user = new { Name = "Tom", Age = 34 };
            var student = new { Name = "Alice", Age = 21 };
            var manager = new { Name = "Alice", Age = 21, Company = "Microsoft" };

            Console.WriteLine($"{user.Name} - {user.Age}");
            // свойства анонимных типов доступны только для чтения и задаются только в инициализаторе

            Console.WriteLine(user.GetType().Name); // <>f__AnonymousType0`2
            Console.WriteLine(student.GetType().Name); // <>f__AnonymousType0`2
            Console.WriteLine(manager.GetType().Name); // <>f__AnonymousType1`3
        }
```

## Инициализаторы с проекцией
```
namespace ConsoleApp4
{
    // инициализаторы с проекцией (projection initializers)
    class User
    {
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User tom = new User { Name = "Tom" };
            int age = 24;
            // инициализатор с проекцией
            var student = new { tom.Name, age };
            // имена используются как названия свойств
            // эквивалентно var student = new { Name = tom.Name, age = age};
            Console.WriteLine(student.Name);
            Console.WriteLine(student.age);

        }
    }
}

```

## Массивы анонимных типов

```
static void Main(string[] args)
        {
            var people = new[]
            {
                new {Name = "Tom" },
                new {Name = "Bob" }
            };
            foreach (var item in people)
                Console.WriteLine(item.Name);
        }
```

## Применение анонимных типов

Если объект используется только один раз, например, для получения выборки, и больше нигде не используется. Создание класса в этом случае може быть избыточным.

Если необходио добавть свойство, то это можно сделать при создании объекта. В случае с классом придется изменять еще и класс.

```
namespace ConsoleApp4
{
    // класс, связывающий наименоване товара с его номером
    class Item
    {
        public string Name { get; set; }
        public int ItemNumber { get; set; }
        public Item(string n, int inum)
        {
            Name = n;
            ItemNumber = inum;
        }
        // класс, связывающий номер товара с его наличием запасов на складе
        class InStockStatus
        {
            public int ItemNumber { get; set; }
            public bool InStock { get; set; }
            public InStockStatus(int n, bool b)
            {
                ItemNumber = n;
                InStock = b;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Item[] items =
                {
                        new Item("У", 1424),
                        new Item("В", 7575),
            new Item("ф", 8645),
                    new Item("Хр", 1448624)
                };
                InStockStatus[] statusList =
                {
                    new InStockStatus(1424, true),
                    new InStockStatus(7575, false),
                    new InStockStatus(1448624, false),
                    new InStockStatus(8645, true),
                };
                // обединить данные в запрос
                var inStockList =
                    from item in items // наименование - номер
                    join entry in statusList // num - true/false
                    on item.ItemNumber equals entry.ItemNumber
                    //возвращает объект анонимного типа
                    select new
                    {
                        Name = item.Name,
                        InStock = entry.InStock
                    };
                Console.WriteLine("Товар    Наличие");
                // Выполнить запрос и отобразить результаты
                foreach (var item in inStockList)
                {
                    Console.WriteLine($"{item.Name,-9} {item.Name,-9}");
                }
            }
        }
    }
    
}
```

## Создание группового соединения

Можно использовать оператор into c join чтобы создать групповое соединение, создающее последовательность, в которой группа в результате состоит из элемента первой последовательности и группы всех соответствующих элементов из второй последовательности.

Пример: групповое соединение для создания списка различных транспортных средств (автомобли, лодки, теплоходы, саолеты) с последующей организацией их в общие категории транспортных средств (наземные, морские, воздушные).

В программе имеется класс транспортных средств, который связывает ви транспортного средства с его категорией

Две последовательности: массив категории транспортнхы средств и массив вида и категории транспортного средства.

Далее создается групповое соединение, чтобы сгенерировать список транспортных средств, в котором они организованы по категориям.

```
namespace ConsoleApp4
{
    class Transport
    { 
        public string Name { get; set; }
        public string How { get; set; }
        public Transport(string n, string h)
        {
            Name = n;
            How = h;
        }
    }

    class Program
    {
        static void Main()
        {
            string[] travelTypes =
            {
                "Воздушный", "Морской", "Наземный", "Речной"
            };
            Transport[] transports =
            {
                new Transport("Велосипед", "Наземный"),
                new Transport("Аэростат", "Воздушный"),
                new Transport("Лодка", "Речной"),
                new Transport("Самолет", "Воздушный"),
                new Transport("Каноэ", "Речной"),
                new Transport("Биплан", "Воздушный"),
                new Transport("Автомашина", "Наземный"),
                new Transport("Судно", "Морской"),
                new Transport("Поезд", "Наземный"),
            };
            var byHow = from how in travelTypes // категории
                        join trans in transports // объединене вид - категория
                        on how equals trans.How
                        into lst // формирование списка по категориям
                        select new { How = how, Tlst = lst };
            // join  - возвращает записи з двух таблиц, отвечающие условию on
            // объект how из списка travelTypes
            // соединяется с объектом trans из списка transport
            // если знаечние how совпадает со значением свойства trans.How.
            // Рехультатом объединения будет объект анонимного типа, содержащий два свойства

            // выполнить апрос и отобразить результаты
            foreach (var item in byHow)
            {
                Console.WriteLine($"{item.How} транспорт: ");
                foreach (var m in item.Tlst)
                    Console.WriteLine("\t" + m.Name);
                Console.WriteLine();
            }
        }
    }
    
}
```