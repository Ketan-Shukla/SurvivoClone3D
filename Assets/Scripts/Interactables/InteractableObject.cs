using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    protected IInteractableAction action;

    private void Update()
    {
        if (action != null)
        {
            action.Update();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (action != null)
        {
            action.Start();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (action != null)
        {
            action.Stop();
        }
    }
}
