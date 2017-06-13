using System.ComponentModel.DataAnnotations;

namespace Black_Jack.Enteties.Enums
{
    public enum CardSuit
    {
        [Display(Name = "Hjärter")]
        Hearts,

        [Display(Name = "Spader")]
        Spades,

        [Display(Name = "Ruter")]
        Diamonds,

        [Display(Name = "Klöver")]
        Clubs
    }
}
