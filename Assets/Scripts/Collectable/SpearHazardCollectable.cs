using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearHazardCollectable : Collectable
{
    // public override void OnPickedUp(CollectableController collectableController)
    // {
    // 	CharacterController character = FindObjectOfType<CharacterController>();
    // 	character.TakeDamage();
    // 	collectableController.OnPickedUp(this);
    // }
    private void Awake()
    {
        collectableType = CollectableType.HAZARD;
    }
}
