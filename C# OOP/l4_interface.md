# Интерфейс

Ссылочный тип, **определяющий набор методов и свойств, но не реализует их**. Затем этот функционал реализуют классы, которые применяют данные интерфейсы.

Интерфейс представляет собой полностью абстрактный класс.

**Отличия интерфейса от абстрактного класса**:
- методы интерфейса объявляются без модификатора доступа (по умолчанию public)
- класс, наследующий интерфейс должен реализовать все методы интерфейса

<br>

Для определения интерфейса используется ключевое слово `interface`
Пример:
```
interface IMovable // название начинается с 'I'
{
    void Move();
}
```

>Интерфейсы **могут** объявлять: методы, св-ва, индексаторы, события, статические поля и константы.
Интерфейсы **не могут** объявлять: нестатические переменные.

Пример:
```
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
```
class Program
{
    static void Main()
    {
        Person p = new Person();
        p.Move;     // Человек идет
        Car c = new Car();
        c.Move;     // Автомобиль едет
        Console.Readkey();
    }
}
```
```
class Program
{
    static void Action(IMovable movable) // Можно передавать любые объекты классов, применяющих данный интерфейс
    {
        movable.Move();
    }
    static void Main()
    {
        Person p = new Person();
        Car c = new Car();
        Action(p);
        Action(c);
        Console.Readkey();

    }
}
```

<br>

# Реалиация интерфейсов в базовых и производных классах
Пример
```
interface IMovable
{
    void Move();
}

abstract class Person : IMovable
{
    public abstract void Move();
}

class Driver : Person
{
    public overrride void Move()
    {
        Console.WriteLine("Да не умер он в конце драйва");
    }
}
```
Пример
```
interface IMovable
{
    void Move();
}

class BaseAction
{
    public void Move()
    {
        Console.WriteLine("Move in BaseAction");
    }
}

class HeroAction : BaseAction, IMovable
{

}
```
```
class Program
{
    static void Action(IMovable movable) // Можно передавать любые объекты классов, применяющих данный интерфейс
    {
        movable.Move();
    }

    static void Main()
    {
        HeroAction h = new HeroAction();
        Action(h);
        h.Move
    }
    Console.Readey();
}
```
<br>

# Множественная реализация интерфейсов
Интерфейсы позволяют частично обойти ограничение множественного наследования, поскольку в C# классы и структуры могут реализовать сразу несколько интерфейсов. Все реализуемые интерфейсы указываются через запятую:
```
class myClass: myInterface1, myInterface2, myInterface3, ...
{
     
}
```
Пример
```
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
}
```