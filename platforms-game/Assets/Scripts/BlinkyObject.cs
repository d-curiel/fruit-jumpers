using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BlinkyObject : MonoBehaviour
{

    SpriteRenderer _sr;

    private bool _blink = false;
    private bool _blinking = false;
    private float _positiveBlink = 0.6f;
    private float _negativeBlink = 0.2f;

    [Header("Config Variables")]
    [SerializeField]
    float _timeBetweenBlinks;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void StartBlink()
    {
        _blinking = true;
        StartCoroutine(Blink());
    }

    public void StopBlink()
    {
        _blinking = false;
        Color tmp = _sr.color;
        tmp.a = 255;
        _sr.color = tmp;
        StopCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (_blinking)
        {
            Color tmp = _sr.color;
            tmp.a = _blink ?  _positiveBlink : _negativeBlink;
            _blink = !_blink;
            _sr.color = tmp;
            yield return new WaitForSeconds(_timeBetweenBlinks);
        }
    }
}
