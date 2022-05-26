using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryFireWork : MonoBehaviour
{
    [SerializeField]
    private GameObject _FireworkObject;
    [SerializeField]
    private Transform _placementTransform;

    public Equipment Equipment;

    [SerializeField]
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();
        _playerInput.Player.UseItem.performed += Action;
    }

    // Update is called once per frame
   //private void Update()
   // {
   //     if ( Equipment.Firework > 0)
   //     {
           
             
   //             Instantiate(_FireworkObject, _placementTransform.position, _placementTransform.rotation);
   //         Equipment.Firework -= 1;
   //     }
   // }

    private void Action(InputAction.CallbackContext context)
    {
        if (this.gameObject.active && Equipment.Firework > 0)
        {


            Instantiate(_FireworkObject, _placementTransform.position, _placementTransform.rotation);
            Equipment.Firework -= 1;
        }
    }

}
