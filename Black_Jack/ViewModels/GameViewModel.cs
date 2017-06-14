using System.Collections.Generic;

namespace Black_Jack.ViewModels
{
    public class GameViewModel
    {
        public GameViewModel(DealerViewModel dealer, IEnumerable<PlayerViewModel> players)
        {
            Players = players;
            Dealer = dealer;
        }

        public DealerViewModel Dealer { get; }
        public IEnumerable<PlayerViewModel> Players { get; }
    }
}