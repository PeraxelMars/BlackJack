using System.Collections.Generic;
using Black_Jack.Enteties;

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
            HasBlackJack = player.HasBlackJack();
        }

        public int Id { get; }
        public string Name { get; }

        public IEnumerable<Card> Hand { get; }
        public bool IsBusted { get; }

        public bool HasBlackJack { get; }

        public int CardValueHigh { get; }

        public int CardValueLow { get; set; }

    }
}