using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
