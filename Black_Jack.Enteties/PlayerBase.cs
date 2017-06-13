using System.Collections.Generic;

namespace Black_Jack.Enteties
{
    public abstract class PlayerBase
    {
        protected PlayerBase(string name)
        {
            Name = name;
        }
        private readonly IList<Card> _hand = new List<Card>();

        public string Name { get; }

        public IEnumerable<Card> Hand => _hand;

        public void AddCardToHand(Card card)
        {
            _hand.Add(card);
        }

        public int GetCardValuesHigh()
        {
            int value = 0;
            foreach (var card in _hand)
            {
                value += card.IsAce() ? 11 : card.Value;
            }

            return value;
        }

        public int GetCardValuesLow()
        {
            int value = 0;
            foreach (var card in _hand)
            {
                value += card.IsAce() ? 1 : card.Value;
            }

            return value;
        }

        public bool IsBusted()
        {
            return GetCardValuesLow() > Constants.BLACK_JACK;
        }

        public bool HasBlackJack()
        {
            return _hand.Count == 2 && GetCardValuesHigh() == Constants.BLACK_JACK;
        }
    }
}
