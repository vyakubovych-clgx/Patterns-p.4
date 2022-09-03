namespace Task4.Players;

public abstract class Player
{
    protected readonly StockExchangeMediator Mediator;

    public int SoldShares { get; private set; }

    public int BoughtShares { get; private set; }

    public event Action NotifySold;
    public event Action NotifyBought;

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
            NotifySold?.Invoke();
        }
        else
        {
            BoughtShares -= numberOfShares;
            NotifyBought?.Invoke();
        }
    }
}