using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopKeeper : InteractableObject
{
    public UnityEvent showShopMenu;

    public UnityEvent hideShopMenu;

    public void DefaultText()
    {
        DialogueBox.Instance.SetTextOnDialogueBox("Welcome", "How can I help you?");
    }

    public void ShowMenu()
    {
        DefaultText();        
        StartCoroutine(MenuStandby());
    }

    public void HideMenu()
    {
        hideShopMenu.Invoke();
    }

    private IEnumerator MenuStandby()
    {
        print("doing something " + DialogueBox.Instance.isActiveAndEnabled);
        yield return new WaitUntil(() => DialogueBox.Instance.isActiveAndEnabled == false);
        print("doing anything " + DialogueBox.Instance.isActiveAndEnabled);
        showShopMenu.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsInteractingWithPlayer = false;
        HideMenu();
    }

}
