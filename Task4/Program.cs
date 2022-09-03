using Task4;
using Task4.Players;

var mediator = new StockExchangeMediator();

var redSocks = new RedSocks(mediator);
redSocks.NotifySold += () => NotifySold(redSocks);
redSocks.NotifyBought += () => NotifyBought(redSocks);

var blossomers = new Blossomers(mediator);
blossomers.NotifySold += () => NotifySold(blossomers);
blossomers.NotifyBought += () => NotifyBought(blossomers);

var rossStones = new RossStones(mediator);
rossStones.NotifySold += () => NotifySold(rossStones);
rossStones.NotifyBought += () => NotifyBought(rossStones);

redSocks.SellOffer("MST", 10);
redSocks.BuyOffer("MST", 10);
blossomers.SellOffer("MST", 10);
blossomers.SellOffer("MST", 10);
rossStones.BuyOffer("MST", 10);
rossStones.BuyOffer("ABC", 10);
redSocks.BuyOffer("ABC", 20);
blossomers.SellOffer("ABC", 15);
blossomers.SellOffer("ABC", 20);
rossStones.BuyOffer("ABC", 15);

Console.ReadLine();

void NotifySold(Player player)
{
    Console.WriteLine($"{player.GetType().Name}.SoldShares is {player.SoldShares}.");
}

void NotifyBought(Player player)
{
    Console.WriteLine($"{player.GetType().Name}.BoughtShares is {player.BoughtShares}.");
}