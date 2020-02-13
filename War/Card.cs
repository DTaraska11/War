namespace War
{

    public class Card
    {
        public CardValue Value;
        public bool ShuffleCard;

        public Card(CardValue value)
        {
            Value = value;
            ShuffleCard = false;
        }
        
    }
}