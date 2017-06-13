using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Black_Jack.Enteties;

namespace Black_Jack.ViewModels
{
    public class DealerViewModel
    {
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