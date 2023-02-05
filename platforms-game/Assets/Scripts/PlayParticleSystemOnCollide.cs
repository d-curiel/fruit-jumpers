using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ParticleSystem))]
public class PlayParticleSystemOnCollide : MonoBehaviour
{

    ParticleSystem _ps;
    public UnityEvent OnPlayParticle;

    private void Awake()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPlayParticle?.Invoke();
        _ps.Play();
    }
}
