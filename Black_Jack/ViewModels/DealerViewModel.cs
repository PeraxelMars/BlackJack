using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Black_Jack.Enteties;

namespace Black_Jack.ViewModels
{
    public class DealerViewModel
    {
        public DealerViewModel(Dealer dealer)
        {
            Name = dealer.Name;
            Hand = dealer.Hand;
            CardValueLow = dealer.GetCardValuesLow();
            CardValueHigh = dealer.GetCardValuesHigh();
            IsBusted = dealer.IsBusted;
            MustStop = dealer.MustStop;
            MustTakeCard = dealer.MustTakeCard;
            HasBlackJack = dealer.HasBlackJack();
        }
        public string Name { get; set; }

        public IEnumerable<Card> Hand { get; set; }
        public bool IsBusted { get; set; }

        public bool MustTakeCard { get; set; }

        public bool MustStop { get; set; }

        public bool HasBlackJack { get; set; }

        public int CardValueHigh { get; set; }

        public int CardValueLow { get; set; }

    }
}