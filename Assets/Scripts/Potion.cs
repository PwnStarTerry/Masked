using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu (menuName = "Items/Potion", fileName = "PotionName.asset")]
public class Potion : Item
{
    public enum PotionType {
        HealthPotion, StaminaPotion, ManaPotion 
    }

    public PotionType potionType;

    public int healAmount;
}
