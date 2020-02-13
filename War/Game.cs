using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace War
{
    public class Game
    {
        private Deck gameDeck;
        private Deck deck1;
        private Deck deck2;
        private int warIndex;
        List<Card> cardPool = new List<Card>();
        private int winnerFlag;

        public Game()
        {
            gameDeck = new Deck();
            deck1 = new Deck();
            deck2 = new Deck();
            warIndex = 1;
            winnerFlag = 0;

        }

        public void GameLoop()
        {
            gameDeck_setup();
            Console.Write("Setting up game deck \n");
            
            gameDeck.Shuffle();
            Console.Write("Shuffling game deck \n");
            deck1_setup();
            Console.Write("Setting up player 1 deck \n");
            deck2_setup();
            Console.Write("Setting up player 2 deck \n");
            gameDeck.cards.Clear();
            
            //Testing test = new Testing();
            
            Console.Write("Game Starting! \n");
            while (winnerFlag == 0 )
            {

                if (deck1.cards.First().ShuffleCard)
                {
                    Console.Write("\n Player 1 has reached front facing card, shuffling deck \n");
                    deck1.cards.First().ShuffleCard = false;
                    deck1.Shuffle();
                    
                }
                if (deck2.cards.First().ShuffleCard)
                {
                    Console.Write("\n Player 2 has reached front facing card, shuffling deck \n");
                    deck2.cards.First().ShuffleCard = false;
                    deck2.Shuffle();
                }
                
                Console.Write("\n Player 1 put down " + deck1.cards.First().Value);
                Console.Write("\n Player 2 put down " + deck2.cards.First().Value);
                if (deck1.cards.First().Value > deck2.cards.First().Value)
                {
                    Console.Write("\n Player 1 wins! They take a " + deck1.cards.First().Value + " and a " + deck2.cards.First().Value);
                    deck1.cards.Add(deck2.cards.First());
                    deck1.cards.Last().ShuffleCard = true;
                    Card t = deck1.cards.First();
                    deck1.cards.RemoveAt(0);
                    deck1.cards.Add(t);
                    deck2.cards.RemoveAt(0);
                    
                }
                else if (deck2.cards.First().Value > deck1.cards.First().Value)
                {
                    Console.Write("\n Player 2 wins! They take a " + deck2.cards.First().Value + " and a " + deck1.cards.First().Value);
                    deck2.cards.Add(deck1.cards.First());
                    deck2.cards.Last().ShuffleCard = true;
                    Card t = deck2.cards.First();
                    deck2.cards.RemoveAt(0);
                    deck2.cards.Add(t);
                    deck1.cards.RemoveAt(0);
                }
                else
                {
                    Console.Write("\n War!");
                    war();
                    cardPool.Clear();
                    
                }

                if (deck1.cards.Count == 52)
                {
                    Console.Write("\nPlayer 1 has collected all 52 cards, they win!\n");
                    winnerFlag = 1;
                }
                if (deck2.cards.Count == 52)
                {
                    Console.Write("\nPlayer 2 has collected all 52 cards, they win!\n");
                    winnerFlag = 2;
                }
                
                //test.listCards(deck1);
                //test.listCards(deck2);
                //test.cardCount(deck1, deck2);
                
                printDecks();
                Console.Write("\nPress enter to continue \n");
                Console.ReadLine();
            }

        } 

        private void gameDeck_setup()
        {
            for (int x = 0; x < 4; x++)
            {
                
                gameDeck.cards.Add(new Card(CardValue.Two));
                gameDeck.cards.Add(new Card(CardValue.Three));
                gameDeck.cards.Add(new Card(CardValue.Four));
                gameDeck.cards.Add(new Card(CardValue.Five));
                gameDeck.cards.Add(new Card(CardValue.Six));
                gameDeck.cards.Add(new Card(CardValue.Seven));
                gameDeck.cards.Add(new Card(CardValue.Eight));
                gameDeck.cards.Add(new Card(CardValue.Nine));
                gameDeck.cards.Add(new Card(CardValue.Ten));
                gameDeck.cards.Add(new Card(CardValue.Jack));
                gameDeck.cards.Add(new Card(CardValue.Queen));
                gameDeck.cards.Add(new Card(CardValue.King));
                gameDeck.cards.Add(new Card(CardValue.Ace));
            }
            
        }

        private void deck1_setup()
        {
            for (int x = 0; x < 26; x++)
            {
                deck1.cards.Add(gameDeck.cards[x]);
            }
            
        }

        private void deck2_setup()
        {
            for (int x = 26; x < 52; x++)
            {
                deck2.cards.Add(gameDeck.cards[x]);
            }
        }

        private void war()
        {
            if (deck1.cards.First() == deck1.cards.Last())
            {
                Console.Write("\nPlayer 1 does not have enough cards to battle, player 2 wins.\n");
                winnerFlag = 2;
                return;
            }
            if (deck2.cards.First() == deck2.cards.Last())
            {
                Console.Write("\nPlayer 2 does not have enough cards to battle, player 1 wins.\n");
                winnerFlag = 1;
                return;
            }
            
            if (deck1.cards[1].ShuffleCard)
            {
                Console.Write("\n Player 1 has reached front facing card, shuffling deck \n");
                deck1.cards.First().ShuffleCard = false;
                deck1.Shuffle();
                    
            }
            cardPool.Add(deck1.cards[1]);
            deck1.cards.RemoveAt(1);
            Console.Write(" \n Player 1 has put a card face down. \n");
            
            if (deck2.cards[1].ShuffleCard)
            {
                Console.Write("\n Player 2 has reached front facing card, shuffling deck \n");
                deck2.cards[1].ShuffleCard = false;
                deck2.Shuffle();
            }
            cardPool.Add(deck2.cards[1]);
            deck2.cards.RemoveAt(1);
            Console.Write(" \n Player 2 has put a card face down \n");
            
            if (deck1.cards.First() == deck1.cards.Last())
            {
                Console.Write("\nPlayer 1 does not have enough cards to battle, player 2 wins.\n");
                winnerFlag = 2;
                return;
            }
            if (deck2.cards.First() == deck2.cards.Last())
            {
                Console.Write("\nPlayer 2 does not have enough cards to battle, player 1 wins.\n");
                winnerFlag = 1;
                return;
            }
            
            Console.Write(" \n Player 1 has put a " + deck1.cards[1].Value + " down \n");
            Card temp1 = deck1.cards[1];
            cardPool.Add(deck1.cards[1]);
            deck1.cards.RemoveAt(1);
            
            Console.Write(" \n Player 2 has put a " + deck2.cards[1].Value + " down \n");
            Card temp2 = deck2.cards[1];
            cardPool.Add(deck2.cards[1]);
            deck2.cards.RemoveAt(1);
            
            if (temp1.Value > temp2.Value)
            {
                
                Console.Write(" \n Player 1 has won the war! ");
                Console.Write("They take: ");
                foreach (Card card in cardPool)
                {
                    Console.Write(card.Value + ", ");
                }
                Console.Write(deck1.cards[0].Value + ", " + deck2.cards[0].Value + " \n");
                int lastCard = deck1.cards.Count;
                deck1.cards.AddRange(cardPool);
                deck1.cards[lastCard].ShuffleCard = true;
                Card t = deck1.cards.First();
                deck1.cards.RemoveAt(0);
                deck1.cards.Add(t);
                deck1.cards.Add(deck2.cards[0]);
                deck2.cards.RemoveAt(0);
                
                


            }
            else if (temp2.Value > temp1.Value)
            {
                
                Console.Write(" \n Player 2 has won the war! \n");
                Console.Write("They take: ");
                foreach (Card card in cardPool)
                {
                    Console.Write(card.Value + ", ");
                }
                Console.Write(deck2.cards[0].Value + ", " + deck1.cards[0].Value + " \n");
                int lastCard = deck2.cards.Count;
                deck2.cards.AddRange(cardPool);
                deck2.cards[lastCard].ShuffleCard = true;
                Card t = deck2.cards.First();
                deck2.cards.RemoveAt(0);
                deck2.cards.Add(t);
                deck2.cards.Add(deck1.cards[0]);
                deck1.cards.RemoveAt(0);
                
                

            }
            else
            {
                Console.Write("\n War!");
                war();
                    
            }


            
        }

        private void printDecks()
        {
            
            Console.Write("\nPlayer 1 Deck:     ");
            foreach (Card card in deck1.cards)
            {
                Console.Write("|");
            }
            Console.Write("\n \n");
            Console.Write("Player 2 Deck:     ");
            foreach (Card card in deck2.cards)
            {
                Console.Write("|");
            }
            Console.Write("\n \n");
        }
        
        
    }
}