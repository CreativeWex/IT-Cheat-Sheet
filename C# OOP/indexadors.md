# Индексаторы

Позволяют индексировать объект подобно массиву (могут иметь одно или несколько измерений).

***Основное назначение*** - поддерживать создание специализированных массивов

<br>

## Синтаксис

```
Доступ ТипЭлемента this[int индекс]
{
    get
    {
        // возвратить значение по индексу
    }
    set
    {
       // установить значение
    }
}
```

Каждый элемент, к которому обращаются через индексатор, имеет ТипЭлемента.

<br>

## Пример

```
class MyArray
{
    int[] a;

    public int Length{get;}

    public MyArray(int size)
    {
        a = new int[size];
        Length = size;
    }
    public int this[int index]
    {
        get{ return a[index]; }
        set{ a[index] = value; }
    }
}
```
```
class Program
{
    static void Main()
    {
        int Length = 5;
        MyArray fs = new MyArray(Length);

        for (int i; i < Lenth; i++)
        {
            fs[i] = i * 10;
        }

        for for (int i; i < Lenth; i++)
        {
            Console.Write($"{fs[i]} ");
        }
        Console.WriteLine();
        Console.WriteLine(fs.Length);
        Console.ReadKey();
    }
}
```

<br>

## Пример: контроль значений индекса

```
class FailSoftArray
{
    int[] a;
    public int Length {get; }
    public bool ErrFlag {get; private set; }

    public FailSoftArray(int size)
    {
        a = new int[size];
        Length = size;
    }

    private bool ok(int index)
    {
        if (index >= 0 && index < Length)
            return true;
        return false;
    }

    public int this[int index]
    {
        get
        {
            if(ok(index))
            {
                ErrFlag = false;
                return a[index];
            }
            ErrFlag = true;
            return -1;
        }
        set
        {
            if (ok(index))
            {
                a[index] = value;
                ErrFlag = false;
            }
            ErrFlag = true;
        }
    }
}
```

```
class Program
{
    static void Main()
    {
        FailSoftArray fs = new FailSoftArray(5);
        Console.WriteLine("\nОтказ при ЗАПАСИ в массив")

        for(int i = 0; i < fs.Length * 2; i++)
        {
            fs[i] = i * 10;
            if (!fs.ErrFlag)
                Console.WriteLine($"fs[{i}] = {fs[i]}");
            else
                Console.WriteLine($"fs[{i}] = Индекс вышел за границу");
        }

        Console.WriteLine("\nОтказ при ЧТЕНИИ в массив")

        for(int i = 0; i < fs.Length * 2; i++)
        {
            fs[i] = i * 10;
            if (!fs.ErrFlag)
                Console.WriteLine($"fs[{i}] = {fs[i]}");
            else
                Console.WriteLine($"fs[{i}] = Индекс вышел за границу");
        }
    }
}
```

<br>

# Перегрузка индексаторов

```
class Person
{
    public string? Name { get; set; } //nullable - тип
    // знак вопроса - тип, допускающий отсутствие ссылки на объект

    public int Age { get; set; }
}

class People
{
    Person[] data;
    public People()
    {
        data = new Person[5];
    }
    public Person this[int index]
    {
        get
        {
            return data[index];
        }
        set
        {
            data[index] = value;
        }
    }
        public Person? this[string name]
    {
        get
        {
            Person? person = null;
            foreach (var p in data)
            {
                if (p?.Name == name)
            }
        }
        set
        {
            data[index] = value;
        }
    }
}
```
```
class Program
{
    static void Main()
    {
        People people = new People();
        people[0] = new Person { Name = "Tom" };
        people[1] = new Person { Name = "Bob" };

        Console.WriteLine(people[0].Name);         // Tom
        Console.WriteLine(people["Bob"]?.Name);    // Bob

        Console.ReadKey();
    }
}
```