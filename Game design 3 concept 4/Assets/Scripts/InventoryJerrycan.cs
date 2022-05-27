using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryJerrycan : MonoBehaviour
{
    [SerializeField]
    private GameObject _BurningCube;
    [SerializeField]
    private Transform _spawnLocation;

    private float _timer;
    [SerializeField]
    private float _maxTime;

    public Equipment Equipment;
    

    [SerializeField]
    private PlayerInput _playerInput;

    private void Start()
    {
        _timer = _maxTime;
        _playerInput = FindObjectOfType<GameLoop>().PlayerInput;

    }



   






    // Update is called once per frame
    void Update()
    {
        if (_playerInput.Player.UseGasoline.ReadValue<float>() != 0 && Equipment.Fuel > 0)
        {
            _timer += Time.deltaTime;
            if (_timer >= _maxTime)
            {
                _timer = 0;
                Instantiate(_BurningCube, _spawnLocation.position, _spawnLocation.rotation);
                Equipment.Fuel -= 1;
            }
        }
    }
}
