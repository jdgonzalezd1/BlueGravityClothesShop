using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    private CustomInput input;

    [SerializeField]
    private GameObject interactKey;

    private bool CanInteract
    {
        get; set;
    }

    private bool InteractingWithClothing
    {
        get; set;
    }

    private bool InteractingWithShopKeeper
    {
        get; set;
    }

    private InteractableObject currentInteractingObject;

    public UnityEvent interactingAction;

    public UnityEvent interactingWithShopKeeperEvent;

    private void Awake()
    {
        input = new CustomInput();
        CanInteract = false;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Controller.performed += _ => OnPlayerInteraction();
        input.Player.Dialog.performed += _ => OnPlayerDialogInteraction();
    }


    private void OnDisable()
    {
        input.Disable();
        input.Player.Controller.performed -= _ => OnPlayerInteraction();
        input.Player.Dialog.performed -= _ => OnPlayerDialogInteraction();

    }
    private void OnPlayerDialogInteraction()
    {
        DialogueBox.Instance.PassToNextLine();
    }

    private void OnPlayerInteraction()
    {
        if (CanInteract)
        {   
            interactingAction.Invoke();            
            if (InteractingWithClothing)
            {
                Clothing tmpClothing = (Clothing)currentInteractingObject;
                DialogueBox.Instance.EnableClothingIcon();
                tmpClothing.LookClothing();                
            }
            else if (InteractingWithShopKeeper)
            {
                interactingWithShopKeeperEvent.Invoke();
            }            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            CanInteract = true;
            interactKey.SetActive(true);
            if(collision.gameObject.GetComponent<Clothing>() != null)
            {
                currentInteractingObject = collision.gameObject.GetComponent<Clothing>();
                InteractingWithClothing = true;
            }else if (collision.gameObject.GetComponent<ShopKeeper>() != null)
            {
                InteractingWithShopKeeper = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CanInteract = false;
        InteractingWithClothing = false;
        InteractingWithShopKeeper = false;
        interactKey.SetActive(false);
    }
}
