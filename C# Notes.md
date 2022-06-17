# Содержание
## .NET
[Перегрузка операторов](#operator_overload) <br>
[1. Абстрактный класс](#T1) <br>
[2. Основные понятия интерфейса](#T2) <br>
[3. Реализация интерфейсов в базовых и производных классах](#T3) <br>
[4. Множественная реализация интерфейсов](#T4) <br>

[5.1. Наследование интерфейсов](#T51) <br>
[5.2. Изменение реализации интерфейсов в производных классах](#T52)<br>
[6. Стандартные интерфейсы](#T6) <br>
[7. Делегаты. Основные понятия](#T7) <br>

[8. Использование методов экземпляра в качестве делегатов](#T8) <br>
[9. Групповые делегаты](#T9) <br>
Обобщенные делегаты (https://metanit.com/sharp/tutorial/3.13.php)<br>
[10. Анонимные методы](#T10) <br>

~~[11. События](#T11)~~ <br>
[22. Анонимные типы](#T22) <br>
[24. Лямбда оператор. Лямбда-выражение](#T24)<br>
[25. Лямбда оператор. Блочные лямбда-выражение](#T25)<br>

[26. Использование лямбда-выражения в конструкторе, свойствах](#T26) <br>
[Индексаторы](#T27.0) <br>
[27. Использование лямбда-выражения в индексаторах, методах](#T27) <br>


## LINQ
[12. Выборка данных с оператором where](#T12) <br>
[13. Выборка данных с сортировкой результатов с помощью orderby](#T13)<br>
[14. Выборка данных с преобразованием результатов отбора](#T14) <br>
[15. Выборка отдельных составных частей элементов источника данных](#T15)<br>

[16. Выборка с формированием последовательности объектов](#T16)<br>
[17. Выборка с группировкой данных](#T17) <br>
[18. Применение оператора into во вложенных запросах](#T18) <br>
[19. Применение оператора let для создания временной переменной в запросе](#T19)<br>
[20. Применение оператора let для хранения неперечислимого значения](#T20) <br>
[21. Объединение двух последовательностей с помощью оператора join](#T21)

[23. Создание группового соединения с операторами into и join](#T23)<br>
~~[28. Методы запроса LINQ](#T28)~~ <br>
~~[29. Создание запроса LINQ с помощью метода запроса](#T29)~~ <br>
~~[30. Режимы выполнения запросов: отоженный и немедленный](#T30)~~ <br><br><br>

<a name="operator_overload"></a>

# Перегрузка операторов

**Определение операторов** заключается в определении в классе, для объектов которого мы хотим определить оператор, специального метода:
```C#
public static возвращаемый_тип operator оператор(параметры)
{  }
```
>Этот метод должен иметь модификаторы public static, так как перегружаемый оператор будет использоваться для всех объектов данного класса.

Один из параметров должен предоставлять тот тип - класс или структуру, в котором определяется оператор.

**Пример**
```C#
class Counter
{
    public int Value { get; set; }
         
    public static Counter operator +(Counter counter1, Counter counter2)
    {
        return new Counter { Value = counter1.Value + counter2.Value };
    }
    public static bool operator >(Counter counter1, Counter counter2)
    {
        return counter1.Value > counter2.Value;
    }
    public static bool operator <(Counter counter1, Counter counter2)
    {
        return counter1.Value < counter2.Value;
    }
}
```
Определить логику можно для следующих операторов:
- унарные операторы `+x, -x, !x, ~x, ++, --, true, false`
- бинарные операторы `+, -, *, /, %`
- операции сравнения `==, !=, <, >, <=, >=`
- поразрядные операторы `&, |, ^, <<, >>`
- логические операторы `&&, ||`

Парные операторы
- `==` и `!=`
- `<` и `>`
- `<=` и `>=`

## Определение инкремента и декремента
```C#
public static Counter operator ++(Counter counter1)
{
    return new Counter { Value = counter1.Value + 10 };
}
```
## Определение true и false
```C#
class Counter
{
    public int Value { get; set; }
     
    public static bool operator true(Counter counter1)
    {
        return counter1.Value != 0;
    }
    public static bool operator false(Counter counter1)
    {
        return counter1.Value == 0;
    }
}
```
>Для использования операции отрицания, типа `if (!counter)`, необходимо определить для типа операцию `!`

<br><a name="T27.0"></a>

# Индексаторы
Позволяют индексировать объекты и обращаться к данным по индексу (работать с объектами как с массивами).

>В отличие от свойств индексатор не имеет названия. Вместо него указывается ключевое слово this, после которого в квадратных скобках идут параметры. Индексатор должен иметь как минимум один параметр.

Синтаксис:
```C#
возвращаемый_тип this [Тип параметр1, ...]
{
    get { ... }
    set { ... }
}
```
Пример применения индекстора:
```C#
class MyArray
{
    int[] a;

    public int Length{get;}

    public MyArray(int size)
    {
        a = new int[size];
        Length = size;
    }
    // индексатор
    public int this[int index]
    {
        get{ return a[index]; }
        set{ a[index] = value; }
    }
}

class Program
{
    static void Main()
    {
        int Length = 5;
        MyArray fs = new MyArray(Length);

        for (int i; i < Lenth; i++)
            fs[i] = i * 10;
        for for (int i; i < Lenth; i++)
            Console.Write($"{fs[i]} ");
        Console.WriteLine();
        Console.WriteLine(fs.Length);
    }
}
```

<hr><br><br><a name="T1"></a>

# Абстрактный класс

Класс, экземпляр которого (объект) **нельзя создать**, используются для описания общего функционала, который могут наследовать и использовать производные классы.

```C#
abstract class Transport
{
    public abstract void Move();
}
```

Абстрактный класс может определять конструкторы, которые будут вызываться в конструкторах производных классов.

<br>

## Абстрактные члены классов

Кроме обычных свойств и методов абстрактный класс может иметь абстрактные члены классов, которые определяются с помощью ключевого слова `abstract` и не имеют никакого функционала. В частности, абстрактными могут быть:
- методы + свойства
- индексаторы
- события

>При этом производный класс обязан переопределить и реализовать все абстрактные методы и свойства, которые имеются в базовом абстрактном классе. 

Если класс имеет хотя бы один абстрактный элемент, то этот класс должен быть определен как абстрактный.

>Абстрактные члены также, как и виртуальные, являются частью полиморфного интерфейса. Но если в случае с виртуальными методами мкласс-наследник наследует реализацию, то в случае с абстрактными методами наследуется интерфейс, представленный этими абстрактными методами.

<br><a name="T2"></a>

# Интерфейсы

Ссылочный тип, **который может определять набор методов и свойств**.  Затем этот функционал реализуют классы и структуры, которые применяют данные интерфейсы.

Методы интерфейса объявляются без модификатора доступа (по умолчанию public)  **ДО ВЕРСИИ С# 8.0**

**До версии С# 8.0 не реализовывали методы и свойства, а только определяли.**
```C#
interface Iназвание // название начинается с 'I'
{
    //Методы
    //Индексаторы
    //События
    //Статические поля и константы, в отличие от абстрактных классов
}
```
Как и классы, интерфейсы по умолчанию имеют уровень доступа `internal`.

Пример:
```C#
interface IMovable // название начинается с 'I'
{
    void Move();
}

class Person : IMovable
{
    public void Move()
    {
        Console.WriteLine("Человек идет");
    }
}

class Car: IMovable
{
    public void Move()
    {
        Console.WriteLine("Автомобиль едет");
    }
}
```
## Модификаторы доступа
Константы и статические переменные, объявленные в интерфейсе будут иметь модификатор `public`. Пример обращения к константам интерфейса `IMovable`:
```C#
Console.WriteLine(IMovable.maxSpeed);   // 60
Console.WriteLine(IMovable.minSpeed);   // 0
```
<a name="T3"></a>

## Реализация интерфейсов в базовых и производных классах
Если класс применяет интерфейс, то этот класс должен реализовать все методы и свойства интерфейса, которые не имеют реализации по умолчанию. **Однако также можно и не реализовать методы, сделав их абстрактными, переложив право их реализации на производные классы:**

```C#
interface IMovable
{
    void Move(); // инициализировали метод
}
abstract class Person : IMovable
{
    public abstract void Move(); //реализовали метод
}
class Driver : Person
{
    public override void Move() => Console.WriteLine("Шофер ведет машину"); //переопределили метод
}
```
<a name="T52"></a>

**Изменение реализации интерфейсов** в произодных классах можно реализовать при помощи виртуальных/абстрактных методов

```C#
interface IAction
{
    void Move();
}
class BaseAction : IAction
{
    public virtual void Move() => Console.WriteLine("Move in BaseAction");
}
class HeroAction : BaseAction
{
    public override void Move() => Console.WriteLine("Move in HeroAction");
}
```

<a name="T4"></a>

## Множественная реализация интерфейсов
Интерфейсы позволяют частично обойти ограничение множественного наследования, поскольку в C# классы и структуры могут реализовать сразу несколько интерфейсов. Все реализуемые интерфейсы указываются через запятую:

```C#
class myClass: myInterface1, myInterface2, myInterface3, ...
{
     // тело
}
```
Пример
```C#
interface IAccount
{
    int CurrentSum {get; }
    void Put(int sum);
    void Withdraw(int sum);
}

interface IClient
{
    string Name {get; set; }
    void Put(int sum);
    void Withdraw(int sum);
}

class Client : IAccount, IClient
{
    int sum;
    public int CurrentSum{ get {return sum; }}
    public string Name {get; set; }
    public void Put(int sum)
    {
        this.su, += sum;
    }
    public void WithDraw(int sum)
    {
        if (this.sum >= sum)
            this.sum -= sum;
    }
}
```
<a name="T51"></a>

## Наследование интерфейсов

```C#
interface IAction
{
    void Move();
}
interface IRunAction : IAction
{
    void Run();
}
class BaseAction : IRunAction
{
    public void Move()
    {
        Console.WriteLine("Move");
    }
    public void Run()
    {
        Console.WriteLine("Run");
    }
}
```
При применении этого интерфейса класс `BaseAction` должен будет реализовать как методы и свойства интерфейса `IRunAction`, так и методы и свойства базового интерфейса `IAction`, если эти методы и свойства не имеют реализации по умолчанию.
<a name="T6"></a><br>

## Стандартные интерфейсы
### IClonable - клонирование объектов

>При присваивании одного экземпляра другому копируется ссылка, а не сам объект. При этом объекты, на которые указывают поля объекта, в свою очередь являющиеся ссылками, не копируются. Это называется **поверхностным клонированием**. Для создания полностью независимых объектов необходимо **глубокое копирование**, когда в памяти создается дубликат всего дерева объектов, то есть объектов, на которые ссылаются поля объекта, поля полей, и т.д.
```C#
public interface IClonable
{
    object Clone();
}
```
Пример поверхностного клонирования
```C#
class Person: ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person()
    {
        Name = "";
    }
    public object Clone()
    {
        return new Person()
        { Name = this.Name, Age = this.Age };
    }
}
class Program
{
    static void Main()
    {
        Person p1 = new Person { Name = "Tom", Age = 23 };
        Person p2 = (Person)p1.Clone();
    }
}
```
Пример глубокого копирования, при котором клон не зависит от оригинала
```C#
class Company
{
    public string Name { get; set; }
    public Company()
    {
        Name = "";
    }
}

class Person: ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Company Work { get; set; }
    public Person()
    {
        Name = "";
        Work = new Company();
    }
    // глубое копирование
    public object Clone()
    {
        Company company = new Company() { Name = this.Work.Name }; // копируем наименование компании
        Person p = new Person() { Name = this.Name, Age = this.Age, Work = company };
        return p;
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Person { Name = "Tom", Age = 23, Work = new Company { Name = "Microsoft" } };
        Console.WriteLine($"\np1:{p1.Name}\t{p1.Age}\t{p1.Work.Name}");
        Person p2 = (Person)p1.Clone(); // Связь не сохраняется
        Console.WriteLine($"\np1:{p1.Name}\t{p2.Age}\t{p2.Work.Name}");
        p1.Name = "Eve";
        p1.Age = 31;
        p1.Work.Name = "Google";
        Console.WriteLine($"\np1:{p1.Name}\t{p1.Age}\t{p1.Work.Name}");
        Console.WriteLine($"\np1:{p2.Name}\t{p2.Age}\t{p2.Work.Name}");
    }
}
```
### IComparable - сравнивание объектов
> Предназначен для сравнения текущего объекта с объектом, на который передается в качестве параметра object o. Возвращает целое число (одно из значений):
- Меньше нуля - текущий объект левее (перед) объекта, передающегося в качестве параметра.
- Равно нулю - текущий объект равен объекту, передающемуся в качестве параметра.
- Больше нуля - текущий объект правее (после) объекта, передающегося в качестве параметра.

```C#
public interface IComparabe
{
    int CompareTo(object o);
}
```
Пример
```C#
class Person : IComparable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person()
    {
        Name = "";
    }
    public int CompareTo(object? ob)
    {
        if (ob is Person p) // шаблон заявления
            return this.Name.CompareTo(p?.Name);
        else
            throw new Exception("Невозможно сравнить объекты");
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Person { Name = "Bill", Age = 32 };
        Person p2 = new Person { Name = "Tom", Age = 23 };
        Person p3 = new Person { Name = "Eve", Age = 21 };
        Person[] people = new Person[] { p1, p2, p3 };
        Array.Sort(people);
        foreach (Person p in people)
            Console.WriteLine($"\n:{p.Name}\t{p.Age}");
        Console.ReadKey();
    }
}        
```
## IComparer - сортировка объектов по различным критериям
`Метод Compare()` предназначен для сравнения объектов о1 и о2.
возвращает целое число:
    - меньше нуля - значит, текущий объект должен находиться перед объектом, который передается в качестве параметра (о1 < o2)
    - равен нулю - одинаковые
    - больше нуля - значит, текущий объект должен находиться после объекта, который передается в качестве параметра (о1 > o2)
```C#
interface IComparer
{
    int Compare(object o1, object o2);
}
```
Пример
```C#
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Person() 
    {
        Name = "";
    }
}

class PeopleComparer : IComparer<Person>
{
    public int Compare(Person? p1, Person? p2)
    {
        if (p1?.Name.Length > p2?.Name.Length)
            return 1;
        else if (p1?.Name.Length < p2?.Name.Length)
            return -1;
        else
            return 0;
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Person { Name = "Bill", Age = 34 };
        Person p2 = new Person { Name = "Tom", Age = 23 };
        Person p3 = new Person { Name = "Alice", Age = 21 };

        Person[] people = new Person[] {p1, p2, p3};
        Array.Sort(people, new PeopleComparer());

        foreach (Person p in people)
            Console.WriteLine($"{p.Name} \t{p.Age}");

        Console.ReadKey();
    }
}
```
<hr><a name="T7"></a><br><br><br>

# Делегаты

**Делегаты** - указатели на методы, с помощью которых можно вызвать данные методы.
```C#
delegate Тип Название(Параметры);
```
**Основное преимущество делегата**: возможность вызова метода, который будет определен во время выполнения работы программы, а не во время копилляции.

>Делегат может указывать на любой метод, который принимает такие же парамеры(**!!! во внимание принимаются модификаторы ref и out**) и имеет такой же возвращаемый тип.

Алгоритм применения делегата:
1. Объявление делегата `delegate void Message();`
2. Для использования делегата создается переменная этого делегата `Message mes;`
3. В делегат передается адрес метода `mes = Hello;`
4. Через делегат вызываем метод, на который он ссылается `mes();`
<a name="T8"></a>

Возможно использование методов экземпляра в качестве делегатов

```C#
delegate void Cmds(string name);
DelegatePerson human = new DelegatePerson { Name = "Alex", Age = 20000 };
Cmds mes = human.SayHello;
mes("John");
```
>При вызове делегата всегда лучше проверять, не равен ли он null
```C#
Message? mes = null;
mes?.Invoke();
```
<a name="T9"></a>

## Групповые делегаты
Делегат может указывать на множество методов, которые имеют ту же сигнатуру и возвращаемые тип. Все методы в делегате попадают в специальный список - список вызова или `invocation list`. И при вызове делегата все методы из этого списка последовательно вызываются. И мы можем добавлять в этот список не один, а несколько методов.

 Для добавления методов в делегат применяется операция `+=`
 Подобным образом мы можем удалять методы из делегата с помощью операций `-=`

 >Делегаты можно объединять в другие делегаты: `del1 = del2 + del3`;

 Если групповой делегат возвращает значение, то значение, возвраенное последним методом в списке,  становится возвращаемым значением всей цепочки вызова.

Поэтому групповой делегат часто имеет пустой тип возвращаемого значения void.

<a name="T10"></a><br>

# Анонимные методы

>Не существует сам по себе, а используются для создания экземпляра делегата.

Анонимные методы **применяются** тогда, когда нам не нужно создавать отдельный метод и он никогда не будет вызван самостоятельно, а только с помощью делегата

Если анонимный метод использует параметры, то они должны соответствовать параметрам делегата. Если для анонимного метода не требуется параметров, то скобки с параметрами опускаются.

Грубо говоря, вместо создания метода, мы вызываем цепочку команд с помощью делегата.

```C#
delegate(параметры)
{
    // инструкции
}
```

**Пример** 
```C#
delegate void CountIt(int end);
class Program
{
    static void Main(string[] args)
    {
        //Объявление делегата с анонимным методом
        CountIt count = delegate(int end)
        {
            for (int i = 0; i <= end; i++)
            {
                Console.Write(i + " ");
            }
        };
        count(3); //вызов инструкций анонимного метода через делегат
        Console.WriteLine();
        count(6);
    }
}
```
**Анонимный метод может возвратить значение**. Значение возвраается с помощью `return`
```C#
delegate int CountIt(int end);
class Program
{
    static void Main(string[] args)
    {
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
    }
}
```
<a name="T11"></a><br>

# События

Событие представляет собой уведомление. Занимает следующее место в иерархии, являясь более высоким, по отошению к делегату, методом абстракции: `метод < делегат < событие`.

## Определение события
```C#
delegate void AccountHandler(string message); // delegate Тип_Делегата Имя_Делегата(Параметры_Делегата);
event AccountHandler Notify;// event Имя_Делегата Имя_События;
```

## Вызов события
```C#
Notify?.Invoke("Произошло действие"); // Имя_События?.Invoke(Параметры_Cобытия);
```
<a name="T22"></a><br>

# Анонимные типы

Позволяют создать объект с некоторым набором свойств без определения класса. **Свойства анонимного типа доступны только для чтения**.

```C#
//var имя_объекта = new { свойство = "значение", свойство = значение, ... };

var user = new { Name = "Tom", Age = 34 };
Console.WriteLine(user.Name);
```
Во время компиляции компилятор сам будет создавать для него имя типа и использовать это имя при обращении к объекту. Если в программе используются несколько объектов анонимных типов с одинаковым набором свойств, то для них компилятор создаст одно определение анонимного типа. **Подобные объекты нельзя преобразовать** к какому-нибудь другому типу, например, классу, даже если он имеет подобный набор свойств.

## Просмотр типа объекта

```C#
//Console.WriteLine(объект.GetType().свойство);

Console.WriteLine(user.GetType().Name); // <>f__AnonymousType0'2
```
## Определение массивов объектов анонимных типов
```C#
var people = new[]
{
    new {Name="Tom"},
    new {Name="Bob"}
};
```
<a name="T24"></a><br>

# Лямбды
**Синтаксис:** слева от лямбда-оператора => определяется список параметров, а справа блок выражений, использующий эти параметры:
```C#
(список_параметров) => выражение
```
Лямбда оператор `=>` используется в:
- лямбда-выражении: `(входные параметры) => выражение`
- блочном лямбда-выражении `(входные параметры) => {выражения}`
- при определении тела выражения `Член класса => выражение;

## Лямбда-выражение
>С точки зрения типа данных лямбда-выражение представляет делегат.

Примеры лямбда-выражений:
```C#
int sum = (x, y) => x + y; // ТипДелегата ИмяПеременной = (Параметры) => Инструкция
int a = sum(4, 5); // a = 9;
```
```C#
public void Display() => Console.WriteLine("=^o.o^=");
```

При применении неявной типизации для предотвращение ошибок следует указать тип параметров
```C#
var sum = (int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");
sum(1, 2);       // 1 + 2 = 3
sum(22, 14);    // 22 + 14 = 36
```
Если лямбда имеет один параметр, для которого не требуется указывать тип данных, то скобки можно опустить:

```C#
delegate void PrintHandler(string message);
PrintHandler print = message => Console.WriteLine(message);
print("Hello");         // Hello
print("Welcome");       // Welcome
```
>Для модификаторов `ref` и `out` обязательно указывать тип
```C#
delegate void Change(ref int x)
{
    int x = 9;
    Change h = (ref int n) => n *= 2;
}
```


<a name="T25"></a>

## Блочное лямбда-выражение
Выполняет блок инструкций. Может возвращать значение с помощью оператора `result`
```C#
var subtract = (int x, int y) =>
{
    if (x > y) return x - y;
    else return y - x;
};
int result1 = subtract(10, 6);  // 4
```
<a name="T26"></a>

## Использование лямбда-выражения в конструкторе, в свойствах
```C#
public class Location
{
    string name;
    // конструктор
    public Location(string name) => this.name = name;

    //свойтво только для чтения
    public string Name => name;

    // свойство
    public string Name
    {
        get => name;
        set => name = value;
    }
}
```
<a name="T27"></a>

## Использование лямбда-выражения в индексаторе, методах.
```C#
public class Sports
{
    private string[] types = { "Football", "Hockey", "Tennis"};
    public string this[int i]
    {
        get => types[i];
        set => types[i] = value;
    }
}
```

<hr><br><br><br><br>

# LINQ
<a name="T12"></a>
<a name="T13"></a>

Запрос состоит из 3 шагов:
1. Источник данных
```C#
int[] nums = new int[] {1, -2, 3, 0 -4 ,5};
```
2. Описание запроса
```C#
var posNums //Название переменной запроса
from n in nums //источник запроса
where n > 0 // where - установить условие
where n < 100 // для нескольких условий
orderby n //ascending - по возрастанию, descending - по убыванию
// orderby Person.Name, Person.Age - несколько критериев
select n; // маркер конца запроса
```

3. Выполнение запроса
```C#
foreach (var i in posNums)
    Console.WriteLine($"{i} ");
```
<a name="T17"></a>
<a name="T19"></a>
## Выборка с группировкой

```C#
string[] web =  { "A.com", "B.net", "C.net", "D.com", "F.org", "H.net", "M.tv", "G.tv" };
var query =
    from i in web
    let idx = addr.LastIndexOf(".");
    where idx != -1
    group i by query.Substring(idx) into ws // инто сохраняет ссылку на группу в переменную
    select ws;

foreach(var i in query)
{
    foreach(var j in i)
    {
        Console.WriteLine($"    {site}");
    }
    Console.WriteLine();
}
```
<a name="T20"></a>

```C#
string[] websites =
{
"A.com", "B.net", "C.net",
"D.com", "E.org", "F.org"
};

//Описание запроса
var webAddrs =
from addr in websites
let idx = addr.LastIndexOf(".")
where idx != -1     //отбор только с точкой
group addr by addr.Substring(idx)   //подстрока
into ws     //группа
where ws.Count() < 3    //последующий отбор групп по колличеству
select ws;  //возврат результата

Console.WriteLine("Группы, имеющие менее трех членов");
foreach (var sites in webAddrs) 
{
foreach (var site in sites)
              Console.WriteLine($"  {site}");
    Console.WriteLine();
}
```
<a name="T18"></a>

# Вложеннные запросы

```C#
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
<a name="T14"></a>

## Выборка с преобразованием результатов отбора
```C#
select n+1;
select Math.Sqrt(n);
```

<a name="T15"></a>

## Выборка отдельных составных частей элементов источника данных
```C#
class EmailAddress
{
    //класс, содержающий два свойства
    public string Name { get; set; }
    public string Address { get; set; }

    public EmailAddress(string n, string a) { Name = n; Address = a; }
}
class Program
{
    static void Main()
    {
        EmailAddress[] addrs =
        {
            new EmailAddress("jack", "Jack@gamil.com"),
            new EmailAddress("Tom", "Tom@gamil.com")
        };

        var eAddrs =
        from entry in addrs
        select entry.Address;

        Console.WriteLine("Адреса электронной почты");
        foreach (string s in eAddrs)
            Console.WriteLine($"{s}");
    }
}
```
<a name="T16"></a>

## Выборка с формированием последовательности объектов
```C#
class ContactInfo
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public ContactInfo(string n, string a, string p)
    {
        Name = n;
        Email = a;
        Phone = p;
    }
}

class EmailAddress
{
    public string Name { get; set; }
    public string Address { get; set; }

    public EmailAddress(string n, string a)
    {
        Name = n;
        Address = a;
    }
}

class Program
{
    static void Main()
    {
        ContactInfo[] contacts =
        {
            new ContactInfo("Юля", "Julia@mail.ru", "562-42-92"),
            new ContactInfo("Alex", "Alex@mail.ru", "562-42-92"),
            new ContactInfo("Igor", "Igor@mail.ru", "562-42-92")
        };

        //запрос для формирования списка объектов EmailAddress
        var emailList =
        from entry in contacts
        select new EmailAddress(entry.Name, entry.Email);

        Console.WriteLine("Список адресов электронной почты");

        //Выполнить запрос и вывести его результаты 
        foreach (EmailAddress e in emailList)
            Console.WriteLine($"{e.Name,-10}: {e.Address}");
    }
}
```
<a name="T21"></a>

## Объединение двух последовательностей
Класс, связывающий наименование товара с его номеромм
```C#
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
```

<a name="T23"></a>

## Создание группового соединения с операторами into и join

```C#
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
```


<a name="T29"></a>
## Создание запроса с помощью метода запроса

```C#
int[] nums = new int[] { 4, -3, -6, 1, 0, 2, -2, 8 };

//Первый
var posNums = nums.Where(n => n > 0).Select(x => Math.Sqrt(x));     // n, x - формальные параметры

foreach (var i in posNums)
Console.Write($"{i:0.000} ");
Console.WriteLine();

//Второй
var posNums2 = nums.Where(n => n % 2 == 0).OrderBy(m => m);

foreach (var i in posNums2)
Console.Write($"{i} ");

// Третий
string[] websites =
{
       "A.com", "B.net", "C.net",
"D.com", "E.org", "F.org"
};

var netAddrs = websites.Where(a => a.Length > 4 && a.EndsWith(".net"));
foreach (var str in netAddrs)
    Console.WriteLine($"{str}");
Console.WriteLine();
```
## Немедленный запрос
<a name="T30"></a>
Count, ToArray, ToList
```C#
int kp = nums.Where(n => n > 0).Count();
```