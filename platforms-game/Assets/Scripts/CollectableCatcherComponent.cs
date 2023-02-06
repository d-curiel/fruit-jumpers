using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableCatcherComponent : MonoBehaviour
{
    [SerializeField]
    private int _collectables = 0;

    public UnityEvent<int> OnCollectablesChange;
    public void CatchCollectable()
    {
        _collectables++;
        OnCollectablesChange?.Invoke(_collectables);
    }
}
