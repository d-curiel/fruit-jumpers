using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableComponent : MonoBehaviour
{
    
    internal void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
