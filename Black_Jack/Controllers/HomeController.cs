using System.Web.Mvc;
using Black_Jack.BL;
using Black_Jack.Enteties;
using Black_Jack.ViewModels;

namespace Black_Jack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InitGame(int players)
        {
            if (HttpContext.Cache["BlackJack"] == null)
            {
                BlackJackGame theGame = new BlackJackGame(players);
                theGame.StartNewRound();

                HttpContext.Cache["BlackJack"] = theGame;
            }

            return View();
        }

        [HttpGet]
        public ActionResult DealCardPlayer(int playerIndex)
        {
            BlackJackGame theGame = (BlackJackGame)HttpContext.Cache["BlackJack"];
            Player player = theGame.Players[playerIndex];
            theGame.DealCard(player);

            PlayerViewModel vm = new PlayerViewModel()
            {
                Name = player.Name,
                Hand = player.Hand,
                CardValueLow = player.GetCardValuesLow(),
                CardValueHigh = player.GetCardValuesHigh(),
                IsBusted = player.IsBusted(),
                HasBlackJack = player.HasBlackJack()
            };
            
            return PartialView("PlayerPartial");
        }

        [HttpGet]
        public ActionResult DealCardDealer()
        {
            BlackJackGame theGame = (BlackJackGame)HttpContext.Cache["BlackJack"];
            Dealer dealer = theGame.Dealer;
            theGame.DealCard(dealer);

            DealerViewModel vm = new DealerViewModel()
            {
                Name = dealer.Name,
                Hand = dealer.Hand,
                CardValueLow = dealer.GetCardValuesLow(),
                CardValueHigh = dealer.GetCardValuesHigh(),
                IsBusted = dealer.IsBusted(),
                HasBlackJack = dealer.HasBlackJack(),
                MustStop = dealer.MustStop,
                MustTakeCard = dealer.MustTakeCard
            };

            return PartialView("PlayerPartial");
        }
    }
}