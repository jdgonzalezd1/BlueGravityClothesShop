using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    private Image clothingIcon;

    [SerializeField]
    private TextMeshProUGUI clothingName;

    [SerializeField]
    private TextMeshProUGUI clothingPrice;


    public void SetItemProperties(Clothes clothingAttributes)
    {
        clothingIcon.sprite = clothingAttributes.icon;
        clothingName.text = clothingAttributes.name;
        clothingPrice.text = clothingAttributes.price;
    }
}
