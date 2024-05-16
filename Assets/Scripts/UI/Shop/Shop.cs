    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private Transform container;

    private ShopItem[] shopItems;

    private Clothing[] availableStock;
    //private int shopStock;

    private void Awake()
    {
        shopItems = container.GetComponentsInChildren<ShopItem>();
        availableStock = FindObjectsByType<Clothing>(FindObjectsSortMode.None);
        SetStockOnShop();
    }

    private void SetStockOnShop()
    {
        foreach (ShopItem item in shopItems)
        {
            item.gameObject.SetActive(false);
        }

        if (availableStock.Length > 0)
        {
            for (int i = 0; i < availableStock.Length; i++)
            {
                shopItems[i].gameObject.SetActive(true);
                shopItems[i].SetItemProperties(availableStock[i].ClothingAttributes);
            }
        }
    }
}
