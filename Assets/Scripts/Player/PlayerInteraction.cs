using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private CustomInput input;

    [SerializeField]
    private bool CanInteract
    {
        get; set;
    }

    private void Awake()
    {
        input = new CustomInput();
        CanInteract = false;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Controller.performed += _ => OnPlayerInteraction();
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Controller.performed -= _ => OnPlayerInteraction();
    }

    private void OnPlayerInteraction()
    {
        if (CanInteract)
        {   
            if (!DialogueBox.Instance.gameObject.activeSelf)
            {
                DialogueBox.Instance.EnableDialogueBox();
            }
            else
            {
                DialogueBox.Instance.PassToNextLine();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            CanInteract = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CanInteract = false;
    }
}
