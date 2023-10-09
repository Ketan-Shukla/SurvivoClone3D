using UnityEngine;

public class ParticleSystemInteractable : InteractableObject
{
    public ParticleSystem actionParticleSystem;

    private void Awake()
    {
        action = new ParticleSystemAction(actionParticleSystem);
    }
}
