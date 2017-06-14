using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public ActionResult TheGame(InitGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            BlackJackGame theGame = new BlackJackGame(model.NumberOfPlayers);
            theGame.StartNewRound();

            HttpContext.Cache["BlackJack"] = theGame;

            GameViewModel vm = new GameViewModel(
                                        new DealerViewModel(theGame.Dealer),
                                        theGame.Players.Select(p => new PlayerViewModel(p)));

            return View(vm);
        }

        [HttpGet]
        public ActionResult DealCardPlayer(int id)
        {
            
            BlackJackGame theGame = (BlackJackGame)HttpContext.Cache["BlackJack"];
            Player player = theGame.Players[id];
            theGame.DealCard(player);


            PlayerViewModel vm = new PlayerViewModel(player);

            return PartialView("_Player");
        }

        [HttpGet]
        public ActionResult DealCardDealer()
        {
            BlackJackGame theGame = (BlackJackGame)HttpContext.Cache["BlackJack"];
            Dealer dealer = theGame.Dealer;
            theGame.DealCard(dealer);

            DealerViewModel vm = new DealerViewModel(dealer);

            return PartialView("PlayerPartial");
        }
    }
}