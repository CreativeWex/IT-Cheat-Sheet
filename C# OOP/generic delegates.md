# Обобщенные делегаты
```C#
delegate Тип Имя <параметры> (аргументы)
```
Преимущество в том, что их допускется определять в типизированной обобщенной форме, которую можно зате согласовать с любым совместимым методом.

Пример
```C#
class Program
    {
        static int Square1(double n)
        {
            return Convert.ToInt32(n * n);
        }
        static double Square2(int n)
        {
            return Convert.ToDouble(n * n);
        }
        delegate Tv Op<T, Tv>(T a);
        static void Main(string[] args)
        {
            Op<double, int> op1 = Square1;
            Console.WriteLine(op1(5));

            Op<int, double> op2 = Square2;
            Console.WriteLine(op2(5));
        }
    }
```
```C#
class Program
    {
        delegate Tv Op<Ta1, Ta2, Tv>(Ta1 a1, Ta2 a2);
        static decimal Sum(int n, double m)
        {
            return Convert.ToDecimal(n + m);
        }
        delegate Tv Op<T, Tv>(T a);
        static void Main(string[] args)
        {
            Op <int, double, decimal> op = Sum;
            Console.WriteLine(op(5, 6.23));
        }
    }
```

# Встроенные делегаты
## Action
Action<T> - принимает 0-16 параметров, возвращает void. Используется как параметры в методах.
```C#
public delegate void Action();
public delegate void Action<T>(T arg);
public delegate void Action<T>(T1 arg1, T2 arg2,);
```
## Predicate
Predicate<T> принимает 1 параметр и возвращает значение `bool`. Использутся для проверки соответствия объекта определенному условию.
```C#
public delegate bool Predicate<T>(T obj);
```
Пример
```C#
static void Main(string[] args)
        {
            Predicate<int> isPositive = delegate (int x) { return x > 0; };
            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));
        }
```
```C#
class Program
    {
        static void Calculate(int value, Predicate<int> filterPredicate)
        {
            if (filterPredicate(value))
                Console.WriteLine(value);
            else
                Console.WriteLine("No");
        }
        static void Main(string[] args)
        {
            int a = 7;
            Calculate(a, delegate (int value) { return value > 5; });
            Calculate(a, delegate (int value) { return value > 23; });
      
```
## Func<T>
Принимает 0-16 параметров, возвращает значение типа TResult. Применяется как параметр в методах.

```C#
public delegate TResult Func<TResult>();
public delegate TResult Func<T, TResult>(T arg);
public delegate TResult Func<T1, T2, TResult>(T1 arg1, T2 arg2);
```
```C#
class Program
    {
        static string ConvertUserString(string impStr)
        {
            return impStr.ToUpper();
        }
        static void Main(string[] args)
        {
            Func<string, string> MethodConvert = ConvertUserString;
            string str = "Владимир";
            Console.WriteLine(MethodConvert(str));
        }
    }
```

```C#
class Program
    {
        public static string MySum(int value1, int value2)
        {
            return (value1 + value2).ToString();
        }
        static void Main(string[] args)
        {
            Func<int, int, string> myFunc = MySum;
            int a = 77, b = 23;
            Console.WriteLine(myFunc(a, b));
        }
    }
```
