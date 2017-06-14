using Black_Jack.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Black_Jack.Enteties;
using Black_Jack.Enteties.Enums;

namespace Black_Jack.Tests.Controllers
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void Player_WhenGivenTwoPictures_ShouldReturn20ForHighAndLow()
        {
            // Arrange
            Player p = new Player(0, "");
            p.AddCardToHand(new Card("Dam", 10));
            p.AddCardToHand(new Card("Kung", 10));

            // Act
            int high = p.GetCardValuesHigh();
            int low = p.GetCardValuesLow();

            // Assert
            Assert.AreEqual(20, high);
            Assert.AreEqual(20, low);
        }

        [TestMethod]
        public void Player_WhenGivenThreePictures_ShouldReturnIsBustedTrue()
        {
            // Arrange
            Player p = new Player(0, "");

            // Act
            p.AddCardToHand(new Card("", 10));
            p.AddCardToHand(new Card("", 10));
            p.AddCardToHand(new Card("", 10));

            // Assert
            Assert.IsTrue(p.IsBusted);
        }

        [TestMethod]
        public void Player_WhenGivenTwoPicturesAndAnAce_ShouldReturnIsBustedFalse()
        {
            // Arrange
            Player p = new Player(0, "");

            // Act
            p.AddCardToHand(new Card("Ace", 11));
            p.AddCardToHand(new Card("", 10));
            p.AddCardToHand(new Card("", 10));

            // Assert
            Assert.IsFalse(p.IsBusted);
        }

        [TestMethod]
        public void Deck_WhenCreatingNewDeckAndShuffle_ShouldContain52Cards()
        {
            // Arrange
            Deck deck = new Deck();
            int expected = 52;

            // Act
            deck.Shuffle();

            // Assert
            Assert.AreEqual(expected, deck.CardsLeft());
        }

        [TestMethod]
        public void BlackJackGame_WhenCreatingNewGameWith4Players_ShouldHave4PlayersAndADealer()
        {
            // Arrange
            BlackJackGame theGame = new BlackJackGame(4);

            // Act
            theGame.StartNewRound();
            int expected = 4;

            // Assert
            Assert.AreEqual(expected, theGame.Players.Count);
            Assert.IsNotNull(theGame.Dealer);
        }

        [TestMethod]
        public void BlackJackGame_WhenDealerAndPlayerHas19Points_ShouldSetPlayerAsLooser()
        {
            // Arrange
            BlackJackGame theGame = new BlackJackGame(1);
            var expected = PlayerGameStatus.Looser;

            // Act
            theGame.Dealer.AddCardToHand(new Card("Kung", 10));
            theGame.Dealer.AddCardToHand(new Card("9", 9));

            theGame.Players[0].AddCardToHand(new Card("Kung", 10));
            theGame.Players[0].AddCardToHand(new Card("9", 9));

            theGame.FinishGame();

            // Assert
            Assert.AreEqual(expected, theGame.Players[0].GameStatus);
        }

        [TestMethod]
        public void BlackJackGame_WhenDealerAndPlayerHas20Points_ShouldSetPlayerGameStatusToTie()
        {
            // Arrange
            BlackJackGame theGame = new BlackJackGame(1);
            var expected = PlayerGameStatus.Tie;

            // Act
            theGame.Dealer.AddCardToHand(new Card("Kung", 10));
            theGame.Dealer.AddCardToHand(new Card("Kung", 10));

            theGame.Players[0].AddCardToHand(new Card("Kung", 10));
            theGame.Players[0].AddCardToHand(new Card("Kung", 10));

            theGame.FinishGame();

            // Assert
            Assert.AreEqual(expected, theGame.Players[0].GameStatus);
        }

        [TestMethod]
        public void BlackJackGame_WhenPlayerHasBJAndDealerHas21_ShouldSetPlayerGameStatusToWinner()
        {
            // Arrange
            BlackJackGame theGame = new BlackJackGame(1);
            var expected = PlayerGameStatus.Winner;

            // Act
            theGame.Dealer.AddCardToHand(new Card("Kung", 10));
            theGame.Dealer.AddCardToHand(new Card("7", 7));
            theGame.Dealer.AddCardToHand(new Card("4", 4));

            theGame.Players[0].AddCardToHand(new Card("Kung", 10));
            theGame.Players[0].AddCardToHand(new Card("Äss", 11));

            theGame.FinishGame();

            // Assert
            Assert.AreEqual(expected, theGame.Players[0].GameStatus);
        }

        [TestMethod]
        public void Dealer_WhenGivenAceAnd6_ShouldReturnMustStopTrue()
        {
            // Arrange
            Dealer dealer = new Dealer();

            // Act
            dealer.AddCardToHand(new Card("", 11));
            dealer.AddCardToHand(new Card("", 6));
            // Assert
            Assert.IsTrue(dealer.MustStop);
        }

        [TestMethod]
        public void Dealer_WhenGivenAceAnd5_ShouldReturnMustStopFalse()
        {
            // Arrange
            Dealer dealer = new Dealer();

            // Act
            dealer.AddCardToHand(new Card("", 11));
            dealer.AddCardToHand(new Card("", 5));
            // Assert
            Assert.IsFalse(dealer.MustStop);
        }
    }
}
