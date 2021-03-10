using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadSample
{
    public class PriceChangedEventArgs : EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;
        public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }
    public class Stock
    {
        string symbol;
        decimal price;
        public Stock(string symbol)
        {
            this.symbol = symbol;
        }
        public event EventHandler<PriceChangedEventArgs> PriceChanged;

        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public decimal Price
        {
            get { return price; }
            set 
            {
                if (price == value)
                {
                    return;
                }
                decimal oldPrice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldPrice, price));
            }
        }
    }


    public static class EventHandlerTest
    {
        static Func<int> func = () => { return 0; };
        static void Foo<T>(T x) { }
        static void Bar<T>(Action<T> a) { }

        static void MyMethod()
        {
            Bar((int x) => Foo(x));
            Bar<int>(x => Foo(x));
            Bar<int>(Foo);
        }
        static Func<int> Natural()
        {
            int seed = 0;
            return () => seed++;
        }

        public delegate void MethodDelegate();

        private static void Add()
        {
            Console.WriteLine("Add");
        }

        //public static void Main()
        //{
        //    Action method = Add;
        //    method();
        //   // Console.WriteLine(method());
        //    Console.ReadKey();

        //    Stock stock = new Stock("MSFT");
        //    stock.Price = 120;
        //    stock.PriceChanged += stock_PriceChanged;
        //    stock.Price = 135;

        //}

        public static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
            {
                Console.WriteLine("Alert, 10% stock price increase.");
            }
        }
    }

}
