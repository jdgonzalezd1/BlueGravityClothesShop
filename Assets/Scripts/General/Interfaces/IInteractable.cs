using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool IsInteractingWithPlayer { get; }

    Collider2D ObjectCollider { get; }
    bool CheckIfCollidingWithPlayer(string argTagName);
}
