using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoopBackground : SoundPlayerInterface
{

    [Header("Audio clips")]
    [SerializeField] AudioClip _clip;


    private void Start()
    {
        _as.clip = _clip;
        _as.loop = true;
        _as.Play();
    }
}
