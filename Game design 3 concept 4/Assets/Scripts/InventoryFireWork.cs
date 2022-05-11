using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryFireWork : MonoBehaviour
{
    [SerializeField]
    private GameObject _FireworkObject;
    [SerializeField]
    private Transform _placementTransform;

    public Equipment Equipment;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Equipment.Firework > 0)
        {
           
             
                Instantiate(_FireworkObject, _placementTransform.position, _placementTransform.rotation);
            Equipment.Firework -= 1;
        }
    }
}
