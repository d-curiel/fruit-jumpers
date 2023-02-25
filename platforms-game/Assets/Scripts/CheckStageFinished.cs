using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CheckStageFinished : MonoBehaviour
{
    [Header("Components")]
    Image _image;

    [Header("Posible Sprites")]

    [SerializeField] Sprite _levelClear;
    [SerializeField] Sprite _levelClearWithFruits;

    [Header("Stage number")]
    [SerializeField] int _stageNumber;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void Start()
    {
        int stageStatus = PlayerPrefs.GetInt("Stage"+ _stageNumber);
        if (stageStatus != 0)
        {
            _image.enabled = true;
            if (stageStatus == 1)
            {
                _image.sprite = _levelClear;
            } else if(stageStatus == 2)
            {

                _image.sprite = _levelClearWithFruits;
            }
        } else
        {
            _image.enabled = false;
        }
    }
}
