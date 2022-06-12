# Индексатор и перегрузка операторов
Создать класс Triangle, разработать элементы класса
1) Поля: dounl a,b,c;
2) Конструктор, позволяющий создать экземпляр класса с заданными длинами сторон.
3) Методы, позволяющие
- вывести длины сторон треугольника на экран
- рассчитать периметр
- площадь
4) Св-ва
- позволяющие получить длины сторон треугольника(только для чтения)
- для установления, существует ли треугольник с данными длинами сторон (get)

В класс Triangle добавить индексатор, позволяющий
- по индекусу 0 обращаться к полю a
- по индекусу 1 обращаться к полю b
- по индекусу 2 обращаться к полю c
- при других значениях индекса выдается сообщение об ошибке

Перегрузку 
- операции ++(--): увеличивает значения всех полей на 1
- констант true false: обращение к экземпляру класса дает значение true в случае существования треугольника иначе false
- Операции *: умножает значения полей a, b, c на скаляр
- преобразоания типа: Triangle в string (и наоборот).

class Triangle
```
class Triangle
    {
        double a, b, c;
        public double A { get { return a; } }
        public double B { get { return b; } }
        public double C { get { return c; } }

        static public bool operator true(Triangle t) { return t.Exists; }
        static public bool operator false(Triangle t) { return t.Exists; }

        static public Triangle operator ++(Triangle t)
        {
            t.a++; t.b++; t.c++;
            return t;
        }
        static public Triangle operator --(Triangle t)
        {
            t.a++; t.b++; t.c++;
            return t;
        }
        public bool Exists
        {
            get
            {
                if (a >= b + c || b >= a + c || c >= b + a)
                    return false;
                return true;
            }
        }

        static public Triangle operator * (Triangle t, double b)
        {
            t.a *= b;
            t.b *= b;
            t.c *= b;
            return t;
        }
        static public Triangle operator *(double b, Triangle t)
        {
            b *= t.a;
            b *= t.b;
            b *= t.c;
            return t;
        }
        public Triangle(){}
        public Triangle(double x, double y, double z)
        {
            a = x; b = y; c = z;
        }
        public void Print()
        {
            Console.WriteLine($"a = {a:0.000} b = {b:0.000} c = {c:0.000}");
        }

        // Индексатор

        public double this[int i]
        {
            get
            {
                if (i == 0) return this.a;
                else if (i == 0) return this.b;
                else if (i == 0) return this.c;
                else Console.WriteLine($"Индекс i = {i} недопустимый");
                return double.NaN;
            }
            private set
            {
                if (i == 0) this.a = value;
                else if (i == 0) this.b = value;
                else if (i == 0) this.c = value;
                else Console.WriteLine($"Индекс i = {i} недопустимый");
            }
        }

        // explicit - явное преобразование типа
        // inplicit - неявное преобразование типа
        static public explicit operator string(Triangle t)
        {
            return ($"{t.a:0.000} {t.b:0.000} {t.c:0.000}");
        }
        static public explicit operator Triangle(string s)
        {
            Triangle t = new Triangle();
            string[] x = s.Split(' ');
            for (int i = 0; i < 3; i++)
                t[i] = Convert.ToDouble(x[i]);
            return t;
        }
    }

```
```
static void Main(string[] args)
        {
            Triangle t1 = new Triangle();
            Console.WriteLine("Конструктор без параметров");
            t1.Print();

            Console.Write("s1: ");
            double s1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("s1: ");
            double s2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("s1: ");
            double s3 = Convert.ToDouble(Console.ReadLine());
            Triangle t = new Triangle(s1, s2, s3);
            Console.WriteLine("Конструктор с параметрами");
            t.Print();

            if (t)
            {
                Console.WriteLine("\nТреугольник постоен");

                Console.WriteLine("\nИнкремент");
                t++;
                t.Print();
                Console.WriteLine("\nДекремент");
                t--;
                t.Print();

                Console.WriteLine("\nУмножение: объект на число");
                t *= 4;
                t.Print();
                Console.WriteLine("\nУмножение: объект на число");
                t = 4 * t;
                t.Print();

                Console.WriteLine("\nСчитывание объекта по индексу");
                for (int i = 0; i < 5; i++)
                    Console.WriteLine($"t[{i}] = {t[i]}:0.000");

                Console.WriteLine("\nПреобразование объекта в строку");
                string ts = (string)t;
                Console.WriteLine("\nЗначения сторон треугольника: ", ts);

                Console.WriteLine("\nПреобразование строки в объект");
                t = (Triangle) ts;

                Console.WriteLine("\nПроверка свойств");
                Console.WriteLine($"A = {t.A:0.000}, B = {t.A:0.000}, C = {t.A:0.000}, ");
            }
            else Console.WriteLine("\nТреугольник не существует");

            Console.ReadKey();
        }
```