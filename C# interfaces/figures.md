class Point
{
    double x, y;
    public double X
    {
        get {return x;}
        set {x = value;}
    }
    public double Y
    {
        get {return y;}
        set {y = value;}
    }
    public Point()
    {
        this.x = x;
        this.y = y;
    }
    public Point() {}
}

interface ISHape
{
    Point Centre {get; set; }
    double Area();
    double Border();

    public double MoveTo(Point point)
    {
        double dX = point.X - Center.X;
        double dy = point.Y - Center.Y;
        double L = Math.Sqrt(dX * dX + dY * dY);
        Point pn = new(point.X, point.Y);
        this.Center = pn;
        return L;
    }
    public void ShowXY()
    {
        Console.WriteLine($"X = {this.Centre.X}, Y = {this.Centre.Y}");
    }
}