# OOP-Poker-Game-Highschool-Project
A game of heads up poker between the user and the CPU implemented in C# during my third year in highschool.

To realize this project I splitted it in 3 main tasks.

## Recognizing and comparing Poker combinations

* the cards in the hand are sorted based on their value and symbol
* based on the order and frequency we search the highest combination that we can make: 
  - 0 for High Card
  - 1 for Pair
  - 2 for Double Pair
  - 3 for Sets
  - 4 for Straight
  - 5 for Flush
  - 6 for Full House
  - 7 for Four of a Kind
  - 8 for Straight Flush
  - 9 for Royal Flush
* when we compare two hands we first compare their hand value and if they have equal value we just compare each card

## The chance to win in the current situation

* we generate random possible outcomes from now on (all of them if they are not too many) and count in how many we win

## The CPU decision

* it is based on his winning chance, the money he currently has left and has bet this game, our current bet and a bit of random

I also used threads so that we can play multiple independent games at once and so that the chance is updated in the time the cards are given
