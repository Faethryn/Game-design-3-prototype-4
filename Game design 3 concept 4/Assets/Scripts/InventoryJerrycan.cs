using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryJerrycan : MonoBehaviour
{
    [SerializeField]
    private GameObject _BurningCube;
    [SerializeField]
    private Transform _spawnLocation;

    private float _timer;
    [SerializeField]
    private float _maxTime;

    private void Start()
    {
        _timer = _maxTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            _timer += Time.deltaTime;
            if (_timer >= _maxTime)
            {
                _timer = 0;
                Instantiate(_BurningCube, _spawnLocation.position, _spawnLocation.rotation);
            }
        }
    }
}