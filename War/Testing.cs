using System;

namespace War
{
    public class Testing
    {
        public Testing()
        {
            
        }

        public void listCards(Deck deck)
        {
            Console.Write("\n");
            foreach (Card card in deck.cards)
            {
                Console.Write(card.Value);
            }
            Console.Write("\n");
        }

        public void cardCount(Deck deck1, Deck deck2)
        {
            Console.Write("\n Deck1 count: " + deck1.cards.Count);
            Console.Write("\n Deck2 count: " + deck2.cards.Count);
        }
    }
}