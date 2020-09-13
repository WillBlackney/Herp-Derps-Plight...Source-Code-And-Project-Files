﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

[Serializable]
public class CardEffect
{
    public CardEffectType cardEffectType;
    public CardWeaponRequirement weaponRequirement;

    [ShowIf("ShowBlockGainValue")]
    public int blockGainValue;

    [ShowIf("ShowBaseDamageValue")]
    public int baseDamageValue;

    [ShowIf("ShowDrawDamageFromBlock")]
    public bool drawBaseDamageFromCurrentBlock;

    [ShowIf("ShowDrawDamageFromTargetPoisoned")]
    public bool drawBaseDamageFromTargetPoisoned;

    [ShowIf("cardEffectType", CardEffectType.DealDamage)]
    public DamageType damageType;

    [ShowIf("cardEffectType", CardEffectType.LoseHealth)]
    public int healthLost;

    [ShowIf("cardEffectType", CardEffectType.GainEnergy)]
    public int energyGained;

    [ShowIf("cardEffectType", CardEffectType.DrawCards)]
    public int cardsDrawn;

    [ShowIf("ShowPassivePairing")]
    public PassivePairingData passivePairing;

    [ShowIf("cardEffectType", CardEffectType.AddCardsToHand)]
    public CardDataSO cardAdded;

    [ShowIf("cardEffectType", CardEffectType.AddCardsToHand)]
    public int copiesAdded;

    public bool ShowPassivePairing()
    {
        if(cardEffectType == CardEffectType.ApplyPassiveToAllAllies ||
            cardEffectType == CardEffectType.ApplyPassiveToAllEnemies ||
            cardEffectType == CardEffectType.ApplyPassiveToSelf ||
            cardEffectType == CardEffectType.ApplyPassiveToTarget)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ShowBlockGainValue()
    {
        if (cardEffectType == CardEffectType.GainBlockSelf ||
            cardEffectType == CardEffectType.GainBlockTarget ||
            cardEffectType == CardEffectType.GainBlockAllAllies)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ShowBaseDamageValue()
    {
        if (cardEffectType != CardEffectType.DealDamage ||
            ((cardEffectType == CardEffectType.DealDamage && drawBaseDamageFromCurrentBlock )||
             (cardEffectType == CardEffectType.DealDamage && drawBaseDamageFromTargetPoisoned))
            )
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool ShowDrawDamageFromBlock()
    {
        if (cardEffectType == CardEffectType.DealDamage &&
            drawBaseDamageFromTargetPoisoned == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool ShowDrawDamageFromTargetPoisoned()
    {
        if (cardEffectType == CardEffectType.DealDamage &&
            drawBaseDamageFromCurrentBlock == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

[Serializable]
public enum CardEffectType
{
    None,
    DealDamage,
    GainBlockSelf,
    GainBlockTarget,
    GainBlockAllAllies,    
    LoseHealth, 
    GainEnergy, 
    DrawCards, 
    ApplyPassiveToSelf, 
    ApplyPassiveToTarget, 
    ApplyPassiveToAllEnemies,
    ApplyPassiveToAllAllies,
    TauntTarget,
    TauntAllEnemies,
    AddCardsToHand,
    RemoveAllPoisonedFromSelf,
    RemoveAllPoisonedFromTarget,
}
