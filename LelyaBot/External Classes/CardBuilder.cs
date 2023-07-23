namespace LelyaBot.External_Classes;

public class CardBuilder
{
    private readonly int[] _cardNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
    private readonly string[] _cardSuits = { "Clubs", "Spades", "Diamonds", "Hearts" };

    public int SelectedNumber { get; internal set; }
    public string SelectedCard { get; internal set; }

    public CardBuilder()
    {
        var Random = new Random();
        int indexNumbers = Random.Next(0, this._cardNumbers.Length - 1);
        int indexSuit = Random.Next(0, this._cardSuits.Length - 1);

        this.SelectedNumber = this._cardNumbers.ElementAt(indexNumbers);
        this.SelectedCard = $"{SelectedNumber} of {this._cardSuits.ElementAt(indexSuit)}";
    }
}