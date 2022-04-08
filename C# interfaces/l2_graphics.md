# Программирование графики
## Основные понятия

Графика поддерживается в **формах**, **панелях**, **компонентах PictureBox**

Доступ к графической поверхности осуществляется через св-во **Graphics** параметра **е** метода обработки события **Paint**

Графической поверхости коспонента соответсвует св-во объект **Graphics**, методы которого обеспчивают вывод графики.

<br>

# Графическая поверхность (холст)

**Холст** состоит из пикселей, характеризующихся координатами, возрастающими сверху вниз и слева направо

<br>

# Карандаш

**Карандаш** определеяеет цвет, толщину и стиль линии; используется для вычерчивания точек, линий, контуров геометрических фигур

Для использования надо создать объект с помощью соответствующего пергружаемого конструктора.
- Pen(Цвет) - 1px
- Pen(Цвет, Толщина)

<br>

### Создание карандаша в обработчике события Paint

```
Pen aPen;
aPen = new Pen(Color.Red, 2); // красный карандаш

e.Graphics.DrawRectangle(aPen, 10, 10, 100, 100) // (карандаш, левый_верхний_угол_х, левый_верхний_угол_у, правый_нижний_угол, правый_нижний_угол,)

a.Width = 2 // 2px
```

Св-во DashStyle определеляет вид линии (сплошная, пунктирная, состоящая из штрихов различной длины)

`DashStyle.Solid` - сплошная

`DashStyle.Dash` - длинный пунктир

`DashStyle.Dot` - короткий пунктир

***using System.Drawing.Drawing2D;***

<br>

# Кисть (заливка)

`Brushes` (Brushes.Red)

`e.Graphics.FillRectangle(Brushes.DeepSkyBlue, x, y, w, h);`

`HatchBrush` - штриховая кисть - заливает штриховкой

- HatchBrush.Horizontal - средняя горизонтальная
- HatchBrush.Vertical - средняя вертикальная
- HatchBrush.LargeGrid - крупная сетка
- HatchBrush.ForwardDiagonal
- HatchBrush.BackwardDiagonal

***using System.Drawing.Drawing2D;***

`HatchBrush br = new HatchBrush(HatchStyle.DottedGrid, Color.Black, Color.SkyBlue);` // кисть закрашивает область синим цветом и сеткой из черных точек

# Графические примитивы

## Линия(цвет, толщина и стиль) определяется карандашом

`DrawLine(aPen, x1, y1, x2, y2);`

`DrawLine(aPen, x1, p1, p2);` // Point p1 = new Point(x, y);

`e.Graphics.DrawLine(Pens.Green, 10, 10, 300, 10);` // зеленая линия толщиной в 1px из (10;10) в (300;10)

## Ломаная линия
`DrawLines(карандаш_Pen, массив_типа_Point_узловых_точек)`

Point[] p = new Point`[5]`;
p[0].X = 10; p[0].Y = 10;

## Прямоугольник

`DrawRectangle(aPen, x, y, w, h);`

Закрашенный прямоугольник

`FillRectangle(Brushes.Blue, x, y, w, h);`

Содание объекта-прямоугольника
```
Rectangle aRect(10, 10, 60, 30);
DrawRectangle(aPen, aReact);
        или
FillRectangle(Brushes.Green, aRect);
```

Фрагмент метода для обработчика событий Paint
```
Rectangle aRect = new Rectangle(10, 10, 60, 30);
e.Graphics.FillRectangle(Brushes.ForestGreen, aRect);

aRect.X = 100; aRect.Y = 10;
e.Graphics.FillRectangle(Brushes.Gold, aRect);
e.Graphics.DrawRectangle(Pens.Red, aReact);
```
## Точка
`e.Graphics.FillRectangle(Brushes.Red, x, y, 1, 1);`

## Многоугольник

`DrawPolygon(ручка, массив_точек);`
`FillPolygon((Brushes.Green, aRect);`

## Эллипс и Окружность

`DrawEllipse(aPen, x, y, w, h);`

## Дуга
`DrawArc(aPen, aRect, startAngle, sweepAngle);`, Величины углов в градусах ( + по часовой, - против)

`DrawPie(aPen, aRect, startAngle, sweepAngle);`

## Вывод текста

`DrawString(текст, шрифт, Brush, x, y);`
Шрифт - Font aFont = new Font("Consolas", 48, FontStyle.Bold | FontStyle.Italic);

## Метод базовой точки
Для сложных изображений, состоящих из нескольких элемент
ов

- Выбиратся базовая тчк изображения
- Коо-рды остальных тчк остчитываются от базовой
- Если коорды тчк изобр-я отчитывать от базовой в относитенльных единицах(dX, dY), а не в пикселах, то обеспеч возможность масштабирования изобр-я