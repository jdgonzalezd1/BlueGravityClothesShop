using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interaction for clothes in scene. Made from scratch
/// </summary>
public class Clothing : InteractableObject
{
    [SerializeField]
    private Clothes clothingAttributes;

    public Clothes ClothingAttributes
    {
        get { return clothingAttributes; }
    }

    public void LookClothing()
    {
        if (IsInteractingWithPlayer && DialogueBox.Instance.isActiveAndEnabled)
        {
            DialogueBox.Instance.SetClothingProperties(clothingAttributes.clothingName, clothingAttributes.price, clothingAttributes.icon);
        }
    }
    
}
