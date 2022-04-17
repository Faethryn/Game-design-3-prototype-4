using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningInteraction : MonoBehaviour, IBurnable
{
    private bool _isBurning;

    [SerializeField]
    private GameObject _burnSensor;

    [SerializeField]
    private GameObject _particleSystem;

    public void Burning()
    {
        _isBurning = true;
        _particleSystem.SetActive(true);
        _burnSensor.SetActive(true);
    }

    public void BurningEvent()
    {

    }
}
