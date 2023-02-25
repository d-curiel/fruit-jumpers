using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneClipListenComponent : SoundPlayerInterface
{

    [Header("Audio clips")]
    [SerializeField] AudioClip _clip;

    public void PlaySound()
    {
        _as.PlayOneShot(_clip);
    }
}
