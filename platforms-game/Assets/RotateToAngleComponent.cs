using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToAngleComponent : MonoBehaviour
{
    /*
     * Tweak this to change frequency
     */
    [SerializeField]
    [Range(50, 95)]
    private int _angle = 75;
    void Update()
    {
        float angle = Mathf.Sin(Time.time) * _angle; 

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
