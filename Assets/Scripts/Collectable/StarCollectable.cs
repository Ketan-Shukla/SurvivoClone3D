using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectable : Collectable
{
    // private CollectableController collectableController;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        collectableType = CollectableType.STAR;
        CollectableController.getInstance().subscribeCollectable(this);
    }

    


    public void OnAnimationComplete()
     {
     collectableController.OnPickedUp(this);
     }

    public void DelayCall(float delay, System.Action callback)
    {
        StartCoroutine(delayCallback(delay, callback));
    }

    IEnumerator delayCallback(float delay, System.Action callback)
    {
        yield return new WaitForSeconds(delay);
        callback();
    }
}
