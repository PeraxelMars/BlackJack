using System.Collections.Generic;
using System.Linq;
using Black_Jack.Enteties;
using Black_Jack.Enteties.Enums;

namespace Black_Jack.BL
{
    public class BlackJackGame
    {
        private const int PlayerLooseLimitWhenSameCardValues = 19;

        public List<Player> Players { get; }
        private readonly Deck _deck;
        public Dealer Dealer { get; }

        public BlackJackGame(int numberOfPlayers)
        {
            _deck = new Deck();
            _deck.Shuffle();
            Players = Enumerable.Range(0, numberOfPlayers).Select(i => new Player(i, $"Player {i + 1}")).ToList();
            Dealer = new Dealer();
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

        public void FinishGame()
        {
            Dealer.HasFinishedGame = true;

            var dealerFinalCardValue = Dealer.GetFinalCardValues();
            var dealerIsBusted = Dealer.IsBusted;

            foreach (var player in Players)
            {
                SetPlayerGameStatus(player, dealerIsBusted, dealerFinalCardValue);
            }
        }

        private void SetPlayerGameStatus(Player player, bool dealerIsBusted, int dealerFinalCardValue)
        {
            if (player.IsBusted)
            {
                player.GameStatus = PlayerGameStatus.Looser;
            }
            else if (dealerIsBusted || player.HasBlackJack && !Dealer.HasBlackJack)
            {
                player.GameStatus = PlayerGameStatus.Winner;
            }
            else
            {
                var playerFinalCardValues = player.GetFinalCardValues();

                if (playerFinalCardValues > dealerFinalCardValue)
                {
                    player.GameStatus = PlayerGameStatus.Winner;
                }
                else if (playerFinalCardValues < dealerFinalCardValue)
                {
                    player.GameStatus = PlayerGameStatus.Looser;
                }
                else if (playerFinalCardValues <= PlayerLooseLimitWhenSameCardValues)
                {
                    player.GameStatus = PlayerGameStatus.Looser;
                }
                else
                {
                    player.GameStatus = PlayerGameStatus.Tie;
                }
            }
        }
    }
}
