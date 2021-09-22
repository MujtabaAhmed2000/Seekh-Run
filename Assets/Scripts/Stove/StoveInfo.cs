using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveInfo : MonoBehaviour
{
    [SerializeField] float flameDuration;
    [SerializeField] float offDuration;
    BoxCollider collider;
    [SerializeField] List<ParticleSystem> flameThrowers;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        Invoke("startFlame", offDuration);
    }

    void startFlame()
    {
        foreach (ParticleSystem particle in flameThrowers)
        {
            particle.Play();
        }
        collider.enabled = true;
        Invoke("stopFlame", flameDuration);
    }

    void stopFlame()
    {
        foreach (ParticleSystem particle in flameThrowers)
        {
            particle.Stop();
        }
        collider.enabled = false;
        Invoke("startFlame", offDuration);
    }
}
