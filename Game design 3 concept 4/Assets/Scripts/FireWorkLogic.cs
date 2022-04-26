using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkLogic : MonoBehaviour, IBurnable
{
    private bool _isBurning;
    private bool _gotMoved = false;
    [SerializeField]
    private float _speed;

    [SerializeField]
    private GameObject _burnSensor;

    [SerializeField]
    private GameObject _particleSystem;
    [SerializeField]
    private Rigidbody _rocketBody;

    public void Burning()
    {
        _isBurning = true;
        _particleSystem.SetActive(true);
        _burnSensor.SetActive(true);
    }

    private void Update()
    {
        if(_isBurning)
        {
            //this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + this.transform.forward, _speed * Time.deltaTime);
           
            _rocketBody.AddForce(this.transform.forward * _speed);
                _gotMoved = true;

            
        }
    }

}
