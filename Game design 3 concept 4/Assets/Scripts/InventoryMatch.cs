using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMatch : MonoBehaviour
{
    [SerializeField]
    private GameObject _ThrowingMatchPrefab;
    [SerializeField]
    private Transform _spawnTransform;

    [SerializeField]
    private int _startingAmount;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && _startingAmount > 0)
        {

            Instantiate(_ThrowingMatchPrefab, _spawnTransform.position, _spawnTransform.rotation);
            _startingAmount -= 1;
        }

    }
}
