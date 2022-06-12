namespace lab_interfaces
{
    interface ICarriage
    {
        int Price
        {
            get {return price;}
            set {price = value;}
        }
        int Places
        {
            get {return places;}
            set {places = value;}
        }
        int totalSum
        {
            get {return totalSum;}
            set {totalSum = value;}
        }
        public void Cost();
        public void Info();
    }
    class General : ICarriage
    {
        int price;
        int places;
        int totalSum;
        public General() {}
        public General(int price, int places, int totalSum)
        {
            this.price = price;
            this.places = places;
            this.totalSum = totalSum;
        }
        public void Cost()
        {
            totalSum = price * totalSum;
            return totalSum;
        }
        public void Info()
        {
            Console.WriteLine($"Цена за место - {price}\tКоличество мест - {places},\tОбщая стоимость - {totalSum}");
        }
    }
    class Reserved : General
    {
        public void Cost()
        {
            
        }
    }
}
