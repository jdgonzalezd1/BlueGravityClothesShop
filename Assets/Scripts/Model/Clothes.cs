using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clothing", menuName = "Clothes")]
public class Clothes : ScriptableObject
{
    public Sprite icon;

    public string clothingName;

    public string price;

    public ClothesType clothingType;    
}

public enum ClothesType
{
    Shirt = 0,
    Pants = 1,
}
