﻿using Match.Cards;

namespace Match.Matchers;

public class SuitAndValueMatcher : IMatcher
{
    public bool IsMatch(Card card1, Card card2)
    {
        return card1.Suit == card2.Suit && card1.Value == card2.Value;
    }
}