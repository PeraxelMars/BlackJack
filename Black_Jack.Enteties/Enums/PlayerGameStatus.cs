using System.ComponentModel.DataAnnotations;

namespace Black_Jack.Enteties.Enums
{
    public enum PlayerGameStatus
    {
        None,

        [Display(Name = "Förlorare")]
        Looser,

        [Display(Name = "Vinnare")]
        Winner,

        [Display(Name = "Lika")]
        Tie
    }
}
