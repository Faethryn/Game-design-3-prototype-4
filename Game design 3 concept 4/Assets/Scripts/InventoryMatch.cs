using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMatch : MonoBehaviour
{
    [SerializeField]
    private GameObject _ThrowingMatchPrefab;
    [SerializeField]
    private Transform _spawnTransform;

    public Equipment Equipment;




    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && Equipment.Match  > 0)
        {

            Instantiate(_ThrowingMatchPrefab, _spawnTransform.position, _spawnTransform.rotation);
            Equipment.Match -= 1;
        }

    }
}
