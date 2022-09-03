using Task1;
using Task1.Players;

var mediator = new StockExchangeMediator();
var redSocks = new RedSocks(mediator);
var blossomers = new Blossomers(mediator);

redSocks.SellOffer("MST", 10);
redSocks.BuyOffer("MST", 10);
blossomers.SellOffer("MST", 10);
blossomers.SellOffer("MST", 10);

Console.ReadLine();