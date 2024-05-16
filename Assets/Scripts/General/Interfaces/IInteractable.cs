using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface used for interacting behaviour. Made from scratch
/// </summary>
public interface IInteractable
{
    bool IsInteractingWithPlayer { get; }

    Collider2D ObjectCollider { get; }
    bool CheckIfCollidingWithPlayer(string argTagName);
}
