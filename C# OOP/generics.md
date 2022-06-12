# Обобщения (generics)

>Позволяют реализовать алгоритм решения независимо от типа данных, а затем применить для обработки разных типов без дополнительных условий.

Обобщение означает параметризованный тип (тип как параметр).

Обобщения позволяют создавать интерфейсы, **классы**, **методы**, **делегаты**, в которых тип обрабатываемых данных указывается в качестве параметра.

Обобщенный код в C# можно создавать оперирую ссылками типа `object`, но при этом возможны ошибки из-за еобходимости преобразования типа `object` в конкретный тип данных.

Эту проблему преодолевают **обобщенные** типы (**универсальные** типы), которы позвляют указывать разные типы.

```C#
class ИмяКласса <Параметры-типы>
{
    ...
}
```
### Пример

```C#
class Account<T>
{
    public T Id {get; set;}
    public decimal Sum {get; set;}
}
```

Создание объекта обобщенного класса

```C#
//ИмяКласса <Типы> ИмяПеременной = new ИмяКласса <Типы> (Агрументы конструтора)

Account <int> account1 = new Account<int>(){Id = 17, Sum = 5000};

Account <string> account1 = new Account<string>(){Id = s17, Sum = 5000};
```

Обобщенный класс с одним параметром-типом
```C#
    class Gen<T>
    {
        T a;
        public Gen(T a)
        {
            this.a = a;
        }
        public T GetA()
        {
            return a;
        }
        public void ShowTypeT()
        {
            Console.WriteLine($"Тип: {typeof(T)}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Gen<int> iOb = new Gen<int>(102);
            iOb.ShowTypeT();
            Console.WriteLine($"Значение {iOb.GetA()}\n");
            Gen<string> strOb = new Gen<string>("Обобщение");
            strOb.ShowTypeT();
            Console.WriteLine($"Значение {strOb.GetA()}\n");
        }
    }
```

Обобщенный класс с двумя параметрами-типами
```C#
class TwoGen<T, V>
    {
        T a;
        V b;
        public TwoGen(T a, V b)
        {
            this.a = a;
            this.b = b;
        }
        public void showTypes()
        {
            Console.WriteLine($"T = {typeof(T)}, V = {typeof(T)}");
        }
        public T GetA()
        {
            return a;
        }
        public V GetB()
        {
            return b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TwoGen<int, string> obTV = new TwoGen<int, string>(119, "Строка");
            obTV.showTypes();
        }
    }
```

# Значения по умолчанию
 

**deafult(T)** присваивает ссылочным типам в качестве значения null, а типам значений - 0

```C#
T id = default(T);
```
# Статические поля обобщенных классов

При типизации обобщенного класса определенным типом будет создаваться свой набор статических членов.

```C#
class Account<t>
{
    public static T s;
}
class Program
{
    static void Main()
    {
        Account<int>.s = 451;
        Account<string>.s = "str"

        Console.WriteLine(Account<int>.s);
        Console.WriteLine(Account<string>.s);
    }
}
```

