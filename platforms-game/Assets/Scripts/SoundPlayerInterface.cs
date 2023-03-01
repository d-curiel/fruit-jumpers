using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class SoundPlayerInterface : MonoBehaviour
{

    protected AudioSource _as;
    [Header("Audio Configuration")]
    [SerializeField]
    [Range(0.1f, 1.0f)]
    float _volume = 0.75f;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
        _as.volume = _volume;
    }
}
