using System.Collections;
using UnityEngine;

public class RotateAction : IInteractableAction
{
    private Transform transform;
    private Vector3 startRotation;
    private Vector3 endRotation;

    private IEnumerator rotateRoutine;

    public RotateAction(Transform transform, Vector3 startRotation, Vector3 endRotation)
    {
        this.transform = transform;
        this.startRotation = startRotation;
        this.endRotation = endRotation;
    }

    public void Start()
    {
        rotateRoutine = RotateRoutine(endRotation);
    }

    public void Stop()
    {
        rotateRoutine = RotateRoutine(startRotation);
    }

    public void Update()
    {
        if (rotateRoutine != null)
        {
            if (!rotateRoutine.MoveNext())
            {
                rotateRoutine = null;
            }
        }
    }

    private IEnumerator RotateRoutine(Vector3 rotation)
    {
        Quaternion originalRotation = transform.localRotation;
        Quaternion targetRotation = Quaternion.Euler(rotation);

        float lerpPercentage = 0.0f;
        while (lerpPercentage < 1.0f)
        {
            transform.localRotation = Quaternion.Lerp(originalRotation, targetRotation, lerpPercentage); ;
            lerpPercentage += Time.deltaTime;
            yield return null;
        }
        transform.localRotation = targetRotation;
    }
}
