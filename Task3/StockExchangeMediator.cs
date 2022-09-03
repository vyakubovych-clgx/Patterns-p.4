using Task3.Players;

namespace Task3;

public class StockExchangeMediator
{
    private readonly Dictionary<Player, List<Offer>> _offers = new();

    public bool MakeOffer(Player player, Offer offer)
    {
        Console.WriteLine($"\n{player.GetType().Name} {(offer.NumberOfShares > 0 ? "sells" : "buys")} {Math.Abs(offer.NumberOfShares)} shares of {offer.StockName}.");
        var otherPlayersRequests = _offers.Where(g => g.Key != player);
        foreach (var otherPlayer in otherPlayersRequests)
        {
            var matchingOffer = otherPlayer.Value.FirstOrDefault(o =>
                o.StockName == offer.StockName && o.NumberOfShares == -offer.NumberOfShares);

            if (matchingOffer is not null)
            {
                otherPlayer.Value.Remove(matchingOffer);
                Console.WriteLine($"The deal was made with {otherPlayer.Key.GetType().Name}.");
                NotifyPlayers(player, otherPlayer.Key, offer);
                return true;
            }
        }

        if (!_offers.TryAdd(player, new List<Offer> { offer }))
            _offers[player].Add(offer);
        Console.WriteLine("The deal was not made yet.");
        return false;
    }

    private static void NotifyPlayers(Player firstPlayer, Player secondPlayer, Offer offer)
    {
        var notifier = offer.NumberOfShares > 0
            ? new DealNotifier(firstPlayer, secondPlayer)
            : new DealNotifier(secondPlayer, firstPlayer);
        notifier.Notify(Math.Abs(offer.NumberOfShares));
    }
}