using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(Animator))]
public class ShootingComponent : MonoBehaviour
{
    [Header("Shooting Variables")]
    [SerializeField]
    List<Transform> _shootingPoints;
    [SerializeField]
    private int _bulletPoolCount = 10;
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _shootDelay;
    private ObjectPool _bulletsPool;

    [Header("Components")]
    private Animator _animator;

    [Header("Bullet Data")]
    [SerializeField]
    private float _maxDistance;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _damage;

    [SerializeField]
    private float _currentDelay;
    [SerializeField]
    private bool _canShoot = false;


    [Header("Events")]
    public UnityEvent OnShoot, OnCantShoot;
    public UnityEvent<float> OnReloading;

    private void Awake()
    {

        _bulletsPool = GetComponent<ObjectPool>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _bulletsPool.Init(_bulletPrefab, _bulletPoolCount);
        _currentDelay = _shootDelay;
    }

    private void Update()
    {
        if (!_canShoot)
        {
            _currentDelay -= Time.deltaTime;
            _canShoot = _currentDelay <= 0;
        }else
        {
            OnShoot?.Invoke();
        }
    }

    public void Shoot()
    {
            _canShoot = false;
            _currentDelay = _shootDelay;
            foreach (Transform shootingPoint in _shootingPoints)
            {
                GameObject bullet = _bulletsPool.CreateObject();
                bullet.transform.position = shootingPoint.position;
                bullet.transform.localRotation = shootingPoint.rotation;
                bullet.GetComponent<BulletController>().Init(_maxDistance, _speed, _damage);
            }
        
    }
}
