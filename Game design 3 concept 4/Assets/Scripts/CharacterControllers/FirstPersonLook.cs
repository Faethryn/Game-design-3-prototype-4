using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    float xRotation = 0f;

    [SerializeField]
    private PlayerInput _playerInput;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerInput = FindObjectOfType<GameLoop>().PlayerInput;

    }

    // Update is called once per frame
    void Update()
    {
        //MouseInput();
        ControllerInput();
    }

    private void ControllerInput()
    {
        float rightStickX = _playerInput.Player.Camera.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;
        float righStickY = _playerInput.Player.Camera.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;
        xRotation -= righStickY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * rightStickX);
    }

    //private void MouseInput()
    //{
    //    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
    //    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    //    xRotation -= mouseY;
    //    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    //    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    //    playerBody.Rotate(Vector3.up * mouseX);

    //}
}
