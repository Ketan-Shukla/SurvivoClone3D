using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CollectableController
{
    private CollectableController() { }
    private static CollectableController instance;

    public static CollectableController getInstance()
    {
        if(instance==null)
        {
            instance = new CollectableController();
        }
        return instance;
    }
    public CollectableController(Transform collectableContainer, CharacterController character)
    {
        Collectable[] collectables = collectableContainer.GetComponentsInChildren<Collectable>();
        foreach (Collectable collectable in collectables)
        {
            // collectable.Setup(this);
            collectable.onPickedUp += onCollectablePickedUp;
        }
    }

    public void subscribeCollectable(Collectable collectable)
    {
        collectable.onPickedUp += onCollectablePickedUp;
    }
    public void unSubscribeCollectable(Collectable collectable)
    {
        collectable.onPickedUp -= onCollectablePickedUp;
    }

    private void onCollectablePickedUp(CollectableType type, GameObject gobj)
    {
        switch (type)
        {
            case CollectableType.STAR:
                StarController starController = GameObject.FindObjectOfType<StarController>();
                starController.PickupStar();
                gobj.GetComponent<Animator>().SetTrigger("pickedUp");
                gobj.GetComponent<StarCollectable>().DelayCall(gobj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * 2,
                () =>
                {
                    OnPickedUp(gobj.GetComponent<Collectable>());
                });
                break;

            case CollectableType.HEALTH:
                CharacterController healthController = GameObject.FindObjectOfType<CharacterController>();
                healthController.BoostHealth();
                OnPickedUp(gobj.GetComponent<Collectable>());
                break;

            case CollectableType.HAZARD:
                CharacterController hazardController = GameObject.FindObjectOfType<CharacterController>();
                hazardController.TakeDamage();
                OnPickedUp(gobj.GetComponent<Collectable>());
                break;
        }
    }

    public void OnPickedUp(Collectable collectable)
    {
        collectable.onPickedUp -= onCollectablePickedUp;
        GameObject.Destroy(collectable.gameObject);
    }
}


