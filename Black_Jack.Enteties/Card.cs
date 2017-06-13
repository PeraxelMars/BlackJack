namespace Black_Jack.Enteties
{
    public class Card
    {
        public Card(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; }

        public int Value { get; }

        public bool IsAce()
        {
            return Value == Constants.CARD_ACE;
        }
    }
}
