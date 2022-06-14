# Делегаты

**Делегат** - тип, позволяющий хранить ссылки на методы. Переменная делегат представляет собой объект, который содержит ссылки на конкретные методы конкретных классов. Заменяя сылку делегата, можно вызть другой метод.

**Основное преимущество делегтата**: возможность вызова етода, который будет определен во время выполнения работы программы, а не во время копилляции.

Объявляются делегаты как методы, но без тела метода и с ключевым словом `delegate`

> Синтаксис: `delegate Тип Имя(параметры)`

Из объявления делегата компиляор генерирует класс, производный от `System.MulticastDelegate`.

## После определения делегата

Можно объявить переменную с типом этого делегата, затем эту переменную можно использовать как ссылку на любой метод, который имеет такой же возвращаемый тип и список параметров, как у делегата(тип-делегат). После этого метод можно вызывать с помощью перемнной-делегата, как будто это есть и сам метод.

Переменную-делегат можно передать в качестве параметра метода, и тогда во время выполнения программы можно вызать метод с помощью этого делегата.

## Итоги

Делегат может использоваться для вызова любого метода, который соответствует его синатуре и типу возвращаемого значения.

Кроме того, вызываемый метод можно определить во время выполнения путем присваивания этому делегату ссылки на совместимый метод.

Может быть вызван метод, связанный с объектом или статический метод, связанный с классом.

# Примеры

В классе имеются три статических метода с одинаковой сигнатурой

```C#
namespace ConsoleApp3
{
    class StringOps
    {
        // Метод: замена пробелов на дефисы
        public static string ReplaceSpaces(string a)
        {
            Console.WriteLine("Заменяет пробелы дефисами");
            return a.Replace(' ', '-');
        }
        // Метод: удаление пробелов
        public static string RemoveSpaces(string a)
        {
            string temp = "";
            int i;

            Console.WriteLine("Удаление пробелов");
            for (i = 0; i < a.Length; i++)
                if (a[i] != ' ') temp += a[i];
            return temp;
        }
        // Реверс строки
        public static string Reverse(string a)
        {
            string temp = "";

            Console.WriteLine("Реверс строки");
            for (int i = a.Length - 1; i >= 0; i--)
                temp += a[i];
            return temp;
        }
    }
    // Имя делегата = его тип, а данном случае StrMod
    delegate string StrMod(string str);
}
```

```C#
class Program
    {
        static void Main()
        {
            // Создать делегат (переменную) и присвоить ссылку на метод
            // используется только имя
            StrMod strOp = StringOps.ReplaceSpaces; // В объект записли ссылку на метод
            // полная форма записи:
            // StrMod strOp = new StrMod(StringOps.ReplaceSpaces);
            string str;
            // Вызов метода через делегата
            str = strOp("Пошли как-то Пупа и Лупа получать зарплату..."); //str = strOp.Invoke("Тест")
            Console.WriteLine("Преобразованная срока: " + str);

            strOp = StringOps.RemoveSpaces; // В объект записли ссылку на метод
            str = strOp("Пошли как-то Пупа и Лупа получать зарплату..."); //str = strOp.Invoke("Тест")
            Console.WriteLine("Преобразованная срока: " + str);

            strOp = StringOps.Reverse; // В объект записли ссылку на метод
            str = strOp("Пошли как-то Пупа и Лупа получать зарплату..."); //str = strOp.Invoke("Тест")
            Console.WriteLine("Преобразованная срока: " + str);
        }
    }
```

Использование методов `экземпляра` в качестве делегатов. Однако, делегат может обратиться также к методам экземпляра `через ссылку на объект`.

Предыдущий пример с инкапсулированием строковых операций в классе StringOps:

>Листинг класса StringOps аналогичен предыдущему примеру, ***только методы не статические***

```C#
static void Main()
        {
            string str;

            StringOps so = new StringOps();
            // Создать делегать и присвоить ссылку на метод
            StrMod strOp = so.ReplaceSpaces;
            str = strOp("Бип Боп");
            Console.WriteLine("Преобразованная срока: " + str);

            strOp = so.RemoveSpaces;
            str = strOp("Бип Боп");
            Console.WriteLine("Преобразованная срока: " + str);

            strOp = so.Reverse;
            str = strOp("Бип Боп");
            Console.WriteLine("Преобразованная срока: " + str);
        }
```

<br>

# Групповые делегаты

**Групповой делегат** - цепочка методов, которые будут вызываться автоматически при вызове делегата. Для создания цепочки создается экземпляр делегата, а затем используется `оператор` `+=`, чтобы добавить метод в список вызовов.

Для удаления используется `оператор` `-=`.



Для демонстрации использования делегата доработаетм рассмотренную ранее программу для обработки строки.

Строковый тип возвращаемого значения методов манипуляции строками заменяем на `void` и используем модификатор параметра `ref`, чтобы возвратить измененную строку вызывающей программе для последующего использования.

```C#
namespace delegates
{
    delegate void StrMod(ref string str);
    class Program
    {
        // Метод: замена пробелов на дефисы
        public static void ReplaceSpaces(ref string a)
        {
            Console.WriteLine("Заменяет пробелы дефисами");
            a = a.Replace(' ', '-');
        }
        // Метод: удаление пробелов
        public static void RemoveSpaces(ref string a)
        {
            string temp = "";
            int i;

            Console.WriteLine("Удаление пробелов");
            for (i = 0; i < a.Length; i++)
                if (a[i] != ' ') temp += a[i];
        }
        // Реверс строки
        public static void Reverse(ref string a)
        {
            string temp = "";

            Console.WriteLine("Реверс строки");
            for (int i = a.Length - 1; i >= 0; i--)
                temp += a[i];
            a = temp;
        }
        static void Main(string[] args)
        {
            string str = "Тест Тест Тест Тест";
            Console.WriteLine("Исходная строка: " + str);

            // Создать делегат
            StrMod strOp = ReplaceSpaces;

            // Создать группу
            strOp += Reverse;

            strOp(ref str);
            Console.WriteLine("Преобразованная строка: " + str + '\n');

            strOp += RemoveSpaces;
            strOp -= ReplaceSpaces;
            str = "Тест Тест Тест Тест";
            Console.WriteLine("Исходная строка: " + str);
            strOp(ref str);
            Console.WriteLine("Преобразованная строка: " + str + '\n');
        }
    }
}
```

# Анонимные методы

Если метод никогда не вызывается самостотельно, а вызывается только через делегата, то с помощбю анонимного метода можно избежать создание отдельного метода.

Анонимный метод представляет собой блок кода, который передается конструктору делегата.

Единственное преимущество использования анонимного метода - простота.

```C#
namespace delegates
{
    delegate void CountIt();
    class Program
    {
        static void Main(string[] args)
        {
            //Объявление делегата с нонимным методом
            CountIt count = delegate
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.Write(i + " ");
                }
            };
            count();
        }
    }
}
```
**Анонимному методу можно передать один или несколько параметров**, список которых указывается после ключевого слова delegate.

Доработаем предыдущую программу, чтобы передавать значение, при котором заканчивается счет в count.
```C#
namespace delegates
{
    delegate void CountIt(int end);
    class Program
    {
        static void Main(string[] args)
        {
            //Объявление делегата с нонимным методом
            CountIt count = delegate(int end)
            {
                for (int i = 0; i <= end; i++)
                {
                    Console.Write(i + " ");
                }
            };
            count(3);
            Console.WriteLine();
            count(6);
        }
    }
}
```

**Анонимный метод может возвратить значение**. Значение возвраается с помощью `return`
```C#
namespace delegates
{
    delegate int CountIt(int end);
    class Program
    {
        static void Main(string[] args)
        {
            //Объявление делегата с нонимным методом
            CountIt count = delegate(int end)
            {
                int sum = 0;
                for (int i = 0; i <= end; i++)
                {
                    Console.Write(i + " ");
                    sum += i;
                }
                return sum;
            };
            count(3);
            Console.WriteLine();
            count(6);
        }
    }
}
```