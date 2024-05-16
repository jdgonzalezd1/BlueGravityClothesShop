using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that manages equipabble (wardrobe) items. Made from scratch but not implemented.
/// 
/// P.D: Yes, I could use an interface for Wardrobe and Shop items. I didn't because
/// the wardrobe behaviour was being developed in the later stages of the project,
/// thus, when time was over, it wasn't refactored appropiately.
/// </summary>
public class WardrobeItem : MonoBehaviour
{
    [SerializeField]
    private Image clothingIcon;

    [SerializeField]
    private TextMeshProUGUI clothingName;

    [SerializeField]
    private TextMeshProUGUI clothingPrice;

    private int itemPrice;

    public void SetItemProperties(Clothes clothingAttributes)
    {
        clothingIcon.sprite = clothingAttributes.icon;
        clothingName.text = clothingAttributes.clothingName;
        clothingPrice.text = $"Price: ${clothingAttributes.price}";
        itemPrice = int.Parse(clothingAttributes.price);
    }

    public void Sell()
    {
        PlayerEconomy.Instance.TryObtainMoney(itemPrice);
    }
}
