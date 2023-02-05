using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationRepeater : MonoBehaviour
{
    private Animator _anim;
    [Header("Config Variables")]
    [SerializeField]
    private float _secondsToStop = 1f;
    [SerializeField] 
    string animationName;
    [SerializeField]
    int _timesToRepeat;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    public void BeginAnimation()
    {
        StartCoroutine(PlayAnimInterval());
    }
    private IEnumerator PlayAnimInterval()
    {
        while (_timesToRepeat > 0)
        {
            _anim.Play(animationName, -1, 0F);
            --_timesToRepeat;
            yield return new WaitForSeconds(_secondsToStop);
        }
    }
}
