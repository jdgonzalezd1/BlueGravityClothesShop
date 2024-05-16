using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    [SerializeField]
    private Transform container;

    private List<ShopItem> equipabbleItems;

    private WardrobeItem[] wardrobeItems;

    private void Awake()
    {
        equipabbleItems = new List<ShopItem>();
        wardrobeItems = container.GetComponentsInChildren<WardrobeItem>();
    }
}
