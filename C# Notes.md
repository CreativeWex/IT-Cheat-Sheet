# Содержание
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


<hr><a name="T1"></a>

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
### IComparable - сравнивание объектов объектов
> Предназначен для сравнения текущего объекта с объектом, на который передается в качестве параметра object o. Возвращает целое число (одно из значений):
- Меньше нуля - текущий объект левее объекта, передающегося в качестве параметра.
- Равно нулю - текущий объект равен объекту, передающемуся в качестве параметра.
- Больше нуля - текущий объект левее объекта, передающегося в качестве параметра.

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
## IComparer - сортировка объектов по раздичным критериям
`Метод Compare()` предназначен для сравнения объектов о1 и о2.
возвращает целое число:
    *меньше нуля - значит, текущий объект должен находиться перед объектом, который передается в качестве параметра (о1 < o2)
    *равен нулю - одинаковые
    *больше нуля - значит, текущий объект должен находиться после объекта, который передается в качестве параметра (о1 > o2)
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
<br><hr><a name="T7"></a>

# Делегаты

**Делегаты** - указатели на методы, с помощью которых можно вызвать данные методы.
```C#
delegate Тип Название(Параметры);
```
**Основное преимущество делегтата**: возможность вызова метода, который будет определен во время выполнения работы программы, а не во время копилляции.

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

 ## Обобщенные делегаты

 


