    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItem;
    private int shopStock;

    private void Awake()
    {
        container = transform.Find("Container");
        shopItem = container.Find("ShopItem");
        shopItem.gameObject.SetActive(false);
    }
}
