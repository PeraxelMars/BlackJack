namespace Black_Jack.Enteties
{
    public class Dealer : PlayerBase
    {
        public Dealer() : base("Dealer")
        {}

        public bool MustTakeCard => GetCardValuesHigh() < Constants.DEALER_MUST_STOP_VALUE;

        public bool MustStop => !MustTakeCard;

        public bool HasFinishedGame { get; set; }
    }
}
