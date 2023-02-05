using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectInstantiator : MonoBehaviour
{
    [Header("Possible Gameobjects")]
    [SerializeField]
    GameObject[] gameObjects;

    private void Awake()
    {
        Instantiate(gameObjects[Random.Range(0, gameObjects.Length - 1)], transform.position, Quaternion.identity);
    }
}
