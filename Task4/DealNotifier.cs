using Task4.Players;

namespace Task4;

public class DealNotifier
{
    private readonly Player _seller;
    private readonly Player _buyer;

    public DealNotifier(Player seller, Player buyer)
    {
        _seller = seller;
        _buyer = buyer;
    }

    public void Notify(int numberOfShares)
    {
        _seller.Update(numberOfShares);
        _buyer.Update(-numberOfShares);
    }
}