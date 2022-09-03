using Task2;
using Task2.Players;

var mediator = new StockExchangeMediator();
var redSocks = new RedSocks(mediator);
var blossomers = new Blossomers(mediator);
var rossStones = new RossStones(mediator);

redSocks.SellOffer("MST", 10);
redSocks.BuyOffer("MST", 10);
blossomers.SellOffer("MST", 10);
blossomers.SellOffer("MST", 10);
rossStones.BuyOffer("MST", 10);
rossStones.BuyOffer("ABC", 10);
redSocks.BuyOffer("ABC", 20);
blossomers.SellOffer("ABC", 15);
blossomers.SellOffer("ABC", 20);

Console.ReadLine();