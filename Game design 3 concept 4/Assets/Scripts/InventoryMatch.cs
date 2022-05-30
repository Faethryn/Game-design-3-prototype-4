using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryMatch : MonoBehaviour
{
    [SerializeField]
    private GameObject _ThrowingMatchPrefab;
    [SerializeField]
    private Transform _spawnTransform;

    public Equipment Equipment;
   
    [SerializeField]
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = FindObjectOfType<GameLoop>().PlayerInput;
        _playerInput.Player.UseItem.performed += Action;
    }

    private void OnDestroy()
    {
        _playerInput.Player.UseItem.performed -= Action;
    }


    private void Action(InputAction.CallbackContext context)
    {
        if (this.gameObject.active && Equipment.Match > 0 && Time.timeScale == 1)
        {

            Instantiate(_ThrowingMatchPrefab, _spawnTransform.position, _spawnTransform.rotation);
            Equipment.Match -= 1;
        }
    }



    // Update is called once per frame
    //void Update()
    //{

    //    if (Input.GetButtonDown("Fire1") && Equipment.Match  > 0)
    //    {

    //        Instantiate(_ThrowingMatchPrefab, _spawnTransform.position, _spawnTransform.rotation);
    //        Equipment.Match -= 1;
    //    }

    //}

}
