using UnityEngine;

public class ParticleSystemAction : IInteractableAction
{
    private ParticleSystem particleSystem;

    public ParticleSystemAction(ParticleSystem particleSystem)
    {
        this.particleSystem = particleSystem;
    }

    public void Start()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }

    public void Stop()
    {
        if (particleSystem != null)
        {
            particleSystem.Stop();
        }
    }

    public void Update()
    { }
}
