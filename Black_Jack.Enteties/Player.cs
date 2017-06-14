namespace Black_Jack.Enteties
{
    public class Player : PlayerBase
    {
        public Player(int id, string name) : base(name)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
