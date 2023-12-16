namespace c_10_in_a_nutshell.Events;

public static class Run
{
    private delegate void PriceChangedHandler(decimal oldPrive, decimal newPrice);
    
    private class PriceChangedEventsArgs : EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventsArgs (decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }

    private class Stock
    {
        string _symbol;
        decimal _price;

        public Stock(string symbol) => _symbol = symbol;

        public event EventHandler<PriceChangedEventsArgs>? PriceChanged;

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price == value) return;
                decimal oldPrice = _price;
                _price = value;
                OnPriceChanged(new PriceChangedEventsArgs(oldPrice, _price));
            }
        }

        protected virtual void OnPriceChanged (PriceChangedEventsArgs e)
            => PriceChanged?.Invoke(this, e);
    }

    private static void Print(object? sender, PriceChangedEventsArgs e) 
    {
        Console.WriteLine($"the old price was {e.LastPrice}, the new is {e.NewPrice}");
    }

    public static void Example01()
    {
        var a = new Stock("milk");
        a.PriceChanged += Print;
        a.Price = 5M;
        a.Price *= 2;
    }
}

