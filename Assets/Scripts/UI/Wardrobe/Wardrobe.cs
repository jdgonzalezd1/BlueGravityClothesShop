using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that manages equipment(wardrobe) menu. Made from scratch but not implemented.
/// </summary>
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
