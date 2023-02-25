using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class SoundPlayerInterface : MonoBehaviour
{

    protected AudioSource _as;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
    }
}
