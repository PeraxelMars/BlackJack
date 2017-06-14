using System.ComponentModel.DataAnnotations;

namespace Black_Jack.ViewModels
{
    public class InitGameViewModel
    {
        [Range(1, 4), Required, Display(Name = "Number of Players")]
        public int NumberOfPlayers { get; set; }
    }
}