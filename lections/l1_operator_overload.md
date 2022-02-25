# Перерузка операторов

<br>

# Двуместные операторы
## Синтаксис
```
public static возвращаемый_тип operator перегруженнный_оператор(Например, + или /) (тип1 операнд1, тип 2 операнд 2)
{
    // операции
}
```

Для двуместных операторов хотя бы один из операндов должен иметь тот же тип, что и класс.

<br>

## Пример: перегрузка двуместных операторов + и -
ThreeD - координаты в трехмерном пространстве

Перегруженный +  добавляет коор-ды одного объекта к  коор-дам другому

Перегруженный - вычитает коор-ды одного объекта из коор-д другого
```
class ThreeD
{
    int x,y,z;

    public ThreeD()
    {
        x = y = z = 0;
    }
    public ThreeD(int i, int j, int k)
    {
        x = i; y = j; z = k;
    }

    // Перегрузка + для объектов ThreeD
    public static ThreeD operator + (ThreeD op1, ThreeD op2)
    {
        ThreeD result = new ThreeD
        {
            x = op1.x + op2.x,
            y = op1.y + op2.y,
            z = op1.z + op2.z,
        };
        return result;
    }

    // Перегрузка - для объектов ThreeD
    // При вычитании важен порядок операндов
    public static ThreeD operator - (ThreeD op1, ThreeD op2)
    {
        ThreeD result = new ThreeD
        {
            x = op1.x - op2.x,
            y = op1.y - op2.y,
            z = op1.z - op2.z,
        };
        return result;
    }

    public void Show()
    {
        Console.Writeline($"{x,2}, {y,2}, {z,2}")
    }
}
```
Метод main():

```
ThreeD a = new ThreeD(1, 2, 3);
ThreeD b = new ThreeD(10, 10, 10);
ThreeD c = new ThreeD();

c = a + b;
c.Show(); // 11,  12,  13

c = a + b + c; // Выполняется последовательно
c.Show(); // 22,  24,  26

c -= a;
c.Show(); // 21,  22,  23
```

<br>
<br>

# Одноместные операторы
## Общая форма перегрузки одноместных операторов

```
public static возвращаемый_тип operator перегруженнный_оператор(Например, + или /) (тип операнд)
{
    // операции
}
```
Оператор должен иметь тип класса

<br>

## Пример
ThreeD - координаты в трехмерном пространстве

Перегруженный ++ увеличивает поля объекта на единицу (рефиксная и постфиксная формы различаются компиллятором автоматически)
Перегруженный - изменяет поля объекта на противоположные

```
class ThreeD
{
    int x,y,z;

    public ThreeD()
    {
        x = y = z = 0;
    }
    public ThreeD(int i, int j, int k)
    {
        x = i; y = j; z = k;
    }

    public static ThreeD operator - (ThreeD op)
    {
        ThreeD result = new ThreeD
        {
            x = -op1.x,
            y = -op1.y,
            z = -op1.z,
        };
        return result;
    }

    public static ThreeD operator ++ (ThreeD op)
    {
        ThreeD result = new ThreeD
        {
            x = op1.x + 1,
            y = op1.y + 1,
            z = op1.z + 1,
        };
        return result;
    }

    public void Show()
    {
        Console.Writeline($"{x,2}, {y,2}, {z,2}")
    }
}
```
Метод main():

```
ThreeD a = new ThreeD(1, 2, 3);
ThreeD c = new ThreeD();

c = -a;
c.Show(); // -1,  -2,  -3

c = a++;
c.Show(); // 2,  3,  4

c = ++a;
c.Show(); // 3,  4,  5
``` 