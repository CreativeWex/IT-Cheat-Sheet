# Лямбды

Лямбда оператор `=>` используется в:
- лямбда-выражении: `(входные параметры) => выражение`
- блочном лямбда-выражении `(входные параметры) => {выражения}`
- при определении тела выражения `Член класса => выражение;`

## Лямбда-выражения
```C#
n => n > 0
count => count + 2;
Func<int, int> square = i => i * i;
Func<int, int, bool> test = (x, y) => x == y;
Func<int, string, bool> Long = (int x, string y) => s.Length > x;
```
для модификаторов `ref` и `out` обязательно указывать тип

```C#
delegate void Change(ref int x)
{
    int x = 9;
    Change h = (ref int n) => n *= 2;
}
```
```C#
delegate bool IsEqual(int x);
private static int Sum(int[] numbers, IsEqual func)
{
    int result = 0;
    foreach(int i in numbers)
    {
        if (func(i))
            result += i;
    }
    return result;
}
```