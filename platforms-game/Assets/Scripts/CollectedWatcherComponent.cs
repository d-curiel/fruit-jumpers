using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectedWatcherComponent : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _textMesh;
    [SerializeField]
    private int _totalCollectables;
    private int _currentCollectables = 0;
    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _totalCollectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
        _textMesh.text = _currentCollectables+"/" + _totalCollectables;
    }
    public void UpdateCollectables(int collectables)
    {
        _currentCollectables = collectables;
        _textMesh.text = _currentCollectables + "/" + _totalCollectables;
    }
}
