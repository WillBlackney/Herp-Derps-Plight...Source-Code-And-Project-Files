﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public Defender owner;
    public CardViewModel cardVM;
    public string cardName;
    public Sprite cardSprite;
    public string cardDescription;
    public int cardBaseEnergyCost;
    public int cardCurrentEnergyCost;
    public CardType cardType;
    public TargettingType targettingType;
    public List<CardEffect> cardEffects = new List<CardEffect>();
}
