using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSoundComponent : SoundPlayerInterface
{

    [Header("Audio clips")]
    [SerializeField] AudioClip _jumpClip;

    public void PlayJumpSound()
    {
        _as.PlayOneShot(_jumpClip);
    }
}
