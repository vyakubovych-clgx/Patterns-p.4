namespace Task3.Players;

public abstract class Player
{
    protected readonly StockExchangeMediator Mediator;

    public int SoldShares { get; private set; }

    public int BoughtShares { get; private set; }

    protected Player(StockExchangeMediator mediator)
    {
        Mediator = mediator;
    }

    public bool SellOffer(string stockName, int numberOfShares)
    {
        var offer = new Offer(stockName, numberOfShares);
        return Mediator.MakeOffer(this, offer);
    }

    public bool BuyOffer(string stockName, int numberOfShares)
    {
        var offer = new Offer(stockName, -numberOfShares);
        return Mediator.MakeOffer(this, offer);
    }

    public void Update(int numberOfShares)
    {
        if (numberOfShares > 0)
        {
            SoldShares += numberOfShares;
            Console.WriteLine($"{this.GetType().Name}.SoldShares is {SoldShares}.");
        }
        else
        {
            BoughtShares -= numberOfShares;
            Console.WriteLine($"{this.GetType().Name}.BoughtShares is {BoughtShares}.");
        }
    }
}