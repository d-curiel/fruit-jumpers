using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSoundComponent : SoundPlayerInterface
{
    [Header("Audio clips")]
    [SerializeField] AudioClip _leftFootstep;
    [SerializeField] AudioClip _rightFootstep;


    public void PlayLeftFootstep()
    {
        _as.PlayOneShot(_leftFootstep);
    }
    public void PlayRightFootstep()
    {
        _as.PlayOneShot(_rightFootstep);
    }
}
