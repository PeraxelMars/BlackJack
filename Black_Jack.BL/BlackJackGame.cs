using System.Collections.Generic;
using System.Linq;
using Black_Jack.Enteties;

namespace Black_Jack.BL
{
    public class BlackJackGame
    {
        public List<Player> Players { get; }
        private readonly Deck _deck;
        public Dealer Dealer { get;}
        private int _currentPlayer;

        public BlackJackGame(int numberOfPlayers)
        {
            _deck = new Deck();
            _deck.Shuffle();
            Players = Enumerable.Range(0, numberOfPlayers).Select(i => new Player($"Player {i+1}")).ToList();
            Dealer = new Dealer();

            _currentPlayer = 0;
        }

        public void StartNewRound()
        {
            for (int i = 0; i < 2; i++)
            {
                Players.ForEach(p => p.AddCardToHand(_deck.GetNextCard()));
            }

            Dealer.AddCardToHand(_deck.GetNextCard());
        }

        public void DealCard(PlayerBase player)
        {
            player.AddCardToHand(_deck.GetNextCard());
        }
    }
}
