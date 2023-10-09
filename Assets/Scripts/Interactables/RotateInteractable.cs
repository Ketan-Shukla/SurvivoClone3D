using UnityEngine;

public class RotateInteractable : InteractableObject
{
    public Transform rotateTransform;
    public Vector3 targetLocalRotation;

    private void Awake()
    {
        action = new RotateAction(rotateTransform, rotateTransform.localEulerAngles, targetLocalRotation);
    }
}
