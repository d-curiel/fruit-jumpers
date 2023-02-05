using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private GameObject _ObjectToPool;
    private Transform _SpawnedObjectParent;

    private int _PoolSize = 10;
    private Queue<GameObject> _ObjectPool;

    private void Awake()
    {
        _ObjectPool = new Queue<GameObject>();
    }

    public GameObject CreateObject()
    {
        CreateParentIfNeeded();
        GameObject spawnedObject;
        if (_ObjectPool.Count < _PoolSize)
        {
            spawnedObject = Instantiate(_ObjectToPool, transform.position, Quaternion.identity);
            spawnedObject.name = transform.root.name + "_" + _ObjectToPool.name + "_" + _ObjectPool.Count;
        } else
        {
            spawnedObject = _ObjectPool.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);

        }
        _ObjectPool.Enqueue(spawnedObject);
        return spawnedObject;


    }
    private void CreateParentIfNeeded()
    {
        if (_SpawnedObjectParent == null)
        {
            string name = "ObjectPool_" + _ObjectToPool.name;
            GameObject parent = GameObject.Find(name);
            if(parent == null)
            {
                _SpawnedObjectParent = new GameObject(name).transform;
            }else
            {
                _SpawnedObjectParent = parent.transform;
            }
        }
    }

    public void Init(GameObject objectToPool, int poolSize = 10)
    {
        _ObjectToPool = objectToPool;
        _PoolSize = poolSize;
    }

    private void OnDestroy()
    {
        foreach(GameObject item in _ObjectPool)
        {
            if(item == null)
            {
                continue;
            } else if (!item.activeSelf)
            {
                Destroy(item);
            }
        }
    }
}
