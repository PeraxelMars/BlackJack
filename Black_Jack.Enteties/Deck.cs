using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Black_Jack.Enteties.Enums;

namespace Black_Jack.Enteties
{
    public class Deck
    {
        public Deck()
        {
            _deck = new List<Card>();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))

            {
                for (int i = 2; i < 15; i++)
                {
                    var cardValue = i > 10 ? (i == 14 ? 11 : 10) : i;
                    _deck.Add(new Card($"{suit.DisplayName()} {i}", cardValue));
                }
            }
        }

        private IList<Card> _deck;

        public Card GetNextCard()
        {
            Card card = _deck.First();
            _deck.RemoveAt(0);
            return card;
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            _deck = _deck.OrderBy(x => rnd.Next(_deck.Count)).ToList();
        }

        public int CardsLeft()
        {
            return _deck.Count;
        }
    }
}
