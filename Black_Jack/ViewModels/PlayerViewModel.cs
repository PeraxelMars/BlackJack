using System.Collections.Generic;
using Black_Jack.Enteties;
using Black_Jack.Enteties.Enums;

namespace Black_Jack.ViewModels
{
    public class PlayerViewModel
    {
        public PlayerViewModel(Player player)
        {
            Id = player.Id;
            Name = player.Name;
            Hand = player.Hand;
            CardValueLow = player.GetCardValuesLow();
            CardValueHigh = player.GetCardValuesHigh();
            IsBusted = player.IsBusted;
            HasBlackJack = player.HasBlackJack;
            GameStatus = player.GameStatus;
        }

        private bool _hasStopped = false;

        public int Id { get; }
        public string Name { get; }

        public IEnumerable<Card> Hand { get; }
        public bool IsBusted { get; }
        public PlayerGameStatus GameStatus { get; }
        public bool HasStopped => _hasStopped;

        public bool HasBlackJack { get; }

        public int CardValueHigh { get; }

        public int CardValueLow { get; set; }

        public void Stop()
        {
            _hasStopped = true;
        }
    }
}