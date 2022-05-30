using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEquipment : MonoBehaviour
{
   

    [SerializeField]
    private GameObject _match;

    [SerializeField]
    private GameObject _jerryCan;

    [SerializeField]
    private GameObject _fireWork;


    private int _itemIndex = 1;

    [SerializeField]
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Enable();
        _playerInput.Player.NextItem.performed += NextItemAction;
        _playerInput.Player.PreviousItem.performed += PreviousItemAction;
    }

    private void OnDestroy()
    {
        _playerInput.Player.NextItem.performed -= NextItemAction;
        _playerInput.Player.PreviousItem.performed -= PreviousItemAction;
    }

    private void NextItemAction(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 1)
        { 
        if (_itemIndex == 3)
        {
            _itemIndex = 1;
        }
        else
        {
            _itemIndex += 1;
        }

        SwitchEquipment();
        }
    }

    private void PreviousItemAction(InputAction.CallbackContext context)
    {
        if (Time.timeScale == 1)
        {


            if (_itemIndex == 1)
            {
                _itemIndex = 3;
            }
            else
            {
                _itemIndex -= 1;
            }

            SwitchEquipment();
        }
    }

   




    private void SwitchEquipment()
    {
       if (_itemIndex == 1)
        {
           
            _match.SetActive(true);
            _jerryCan.SetActive(false);
            _fireWork.SetActive(false);
        }
        if (_itemIndex == 2)
        {
          
            _match.SetActive(false);
            _jerryCan.SetActive(true);
            _fireWork.SetActive(false);
        }
    
        if (_itemIndex == 3)
        {
           
         _match.SetActive(false);
            _jerryCan.SetActive(false);
            _fireWork.SetActive(true);
        }
        
    }

  

    
}
