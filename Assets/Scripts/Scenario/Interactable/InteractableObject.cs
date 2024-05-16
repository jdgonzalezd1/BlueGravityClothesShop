using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class that implements interacting behaviour. Made from scratch
/// </summary>
[RequireComponent(typeof(PolygonCollider2D))]
public class InteractableObject : MonoBehaviour , IInteractable
{
    public bool IsInteractingWithPlayer
    {
        set; get;
    }

    Collider2D IInteractable.ObjectCollider
    {
        get { return GetComponent<Collider2D>(); }
    }


    private void FixedUpdate()
    {
        if (IsInteractingWithPlayer)
        {
            print("Interacting...");
        }
    }

    public bool CheckIfCollidingWithPlayer(string argTagName)
    {
        if (argTagName == "Player") 
        { 
            return true;
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CheckIfCollidingWithPlayer(collision.gameObject.tag))
        {
            IsInteractingWithPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsInteractingWithPlayer = false;
    }
}
