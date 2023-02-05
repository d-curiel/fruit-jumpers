using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCatcherComponent : MonoBehaviour
{
    [SerializeField]
    private int _collectables = 0;

    public void CatchCollectable()
    {
        _collectables++;
    }
}
