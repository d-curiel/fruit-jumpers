using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSoundComponent : SoundPlayerInterface
{

    [Header("Audio clips")]
    [SerializeField] AudioClip _deadClip;

    public void PlayDeadSound()
    {
        _as.PlayOneShot(_deadClip);
    }
}
