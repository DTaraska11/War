using System;
using System.Collections.Generic;

namespace War
{
    public class Deck
    {
        public List<Card> cards;
        


        public Deck()
        {
            cards = new List<Card>();
            
        }

        public void Shuffle()
        {
            //change to for each??
            Random rng = new Random(); 
            int n = cards.Count;
            
                while (n > 1) {  
                    n--;  
                    int k = rng.Next(n + 1);  
                    Card v = cards[k];  
                    cards[k] = cards[n];  
                    cards[n] = v;  
                }
                
                resetShuffleFlag();
        }

        public void resetShuffleFlag()
        {
            foreach (Card card in cards)
            {
                card.ShuffleCard = false;
            }
        }
    }
}