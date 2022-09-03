namespace Task1.Players;

public abstract class Player
{
    protected readonly StockExchangeMediator Mediator;

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
}