# Стандартный интерфейс IClonable

Поддерживает клонирование объектов класса

public interface IClonable
{
    object Clone();
}

Пример клонирования
```
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
            Console.WriteLine($"\np1:{p1.Name}\t{p1.Age}");
            Person p2 = (Person)p1.Clone();
            Console.WriteLine($"\np2:{p2.Name}\t{p2.Age}");

            p1.Name = "Eve";
            p1.Age = 31;
            Console.WriteLine($"\np1:{p1.Name}\t{p1.Age}");
            Console.WriteLine($"\np2:{p2.Name}\t{p2.Age}");


            Console.ReadKey();
        }
    }
```
## Глубокое копирование (клон не зависит от оригинала)
```
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

            Console.ReadKey();
        }
    }
```
<br>

# Сортировка объектов
## Интерфейс IComparable
Синтаксис
```
public interface IComparabe
{
    int CompareTo(object o);
}
```
Метод: `o1.CompareTo(o2);`
> Предназначен для сравнения текущего объекта с объектом, на который передается в качестве параметра object o. Возвращает целое число (одно из значений):
- Меньше нуля - текущий объект левее объекта, передающегося в качестве параметра.
- Равно нулю - текущий объект равен объекту, передающемуся в качестве параметра.
- Больше нуля - текущий объект левее объекта, передающегося в качестве параметра.

```
//class Person: IComparable
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public Person()
    //    {
    //        Name = "";
    //    }
    //    public int CompareTo(object ob) // object? ob
    //    {
    //        Person p = ob as Person; // Person? p = ob as Person;
    //        if (p != null)
    //            return this.Name.CompareTo(p.Name); // return this.Name.CompareTo(p?.Name);
    //        else
    //            throw new Exception("Невозможно сравнить объекты");
    //    }
    //}

    // В СОКРАЩЕННОМ ВИДЕ

    class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person()
        {
            Name = "";
        }
        public int CompareTo(object ob) // object? ob
        {
            if (ob is Person p) // шаблон заявления
                return this.Name.CompareTo(p.Name); //p?.Name
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

# IComparer
```
interface IComparer
{
    int Compare(object o1, object o2);
}
```

Сравнивает 2 объекта

-интерфейс IComparer-
##В нем заявлен один метод. Возвр тип int
public interface IComparable
{
    int Compare(object o1, object o2);
}

Метод Compare()
предназначен для сравнения объектов о1 и о2.
возвращает целое число:
    *меньше нуля - значит, текущий объект должен находиться перед объектом, который передается в качестве параметра (о1 < o2)
    *равен нулю - одинаковые
    *больше нуля - значит, текущий объект должен находиться после объекта, который передается в качестве параметра (о1 > o2)

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