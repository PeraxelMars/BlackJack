using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Black_Jack.BL;
using Black_Jack.Enteties;
using Black_Jack.ViewModels;

namespace Black_Jack.Controllers
{
    [OutputCache(NoStore = true, Duration = 0)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InitGame(InitGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            BlackJackGame theGame = new BlackJackGame(model.NumberOfPlayers);
            theGame.StartNewRound();

            Session["BlackJack"] = theGame;

            return RedirectToAction(nameof(TheGame));
        }

        public ActionResult TheGame()
        {
            if (Session["BlackJack"] == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var theGame = GetGame();

            GameViewModel vm = new GameViewModel(
                                    new DealerViewModel(theGame.Dealer),
                                    theGame.Players.Select(p => new PlayerViewModel(p)));

            return View(vm);
        }

        [HttpGet]
        public PartialViewResult DealCardPlayer(int id)
        {

            var theGame = GetGame();
            Player player = theGame.Players[id];
            theGame.DealCard(player);

            PlayerViewModel vm = new PlayerViewModel(player);

            return PartialView("_Player", vm);
        }

        [HttpGet]
        public ActionResult PlayerStop(int id)
        {
            var theGame = GetGame();
            Player player = theGame.Players[id];

            PlayerViewModel vm = new PlayerViewModel(player);
            vm.Stop();

            return PartialView("_Player", vm);
        }

        [HttpGet]
        public PartialViewResult DealCardDealer()
        {
            var theGame = GetGame();
            Dealer dealer = theGame.Dealer;
            theGame.DealCard(dealer);

            DealerViewModel vm = new DealerViewModel(dealer);

            return PartialView("_Dealer", vm);
        }

        public ActionResult FinishGame()
        {
            var theGame = GetGame();
            theGame.FinishGame();
            return RedirectToAction(nameof(TheGame));
        }
        private BlackJackGame GetGame()
        {
            return (BlackJackGame)Session["BlackJack"];
        }
    }
}