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

    [SerializeField]
    private float _lifetime;

    private float _timer;

    [SerializeField]
    private float _range;
    [SerializeField]
    private float _force;
    [SerializeField]
    private LayerMask _interactibleLayers;

    [SerializeField]
    private GameObject _fireWorkParticlePrefab;


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
            _timer += Time.deltaTime;
            
        }


        if (_timer >= _lifetime)
        {


            Collider[] collidersInRange = Physics.OverlapSphere(this.transform.position, _range, _interactibleLayers);
            foreach (Collider collider in collidersInRange)
            {
                IEffectable effectableScript = collider.gameObject.GetComponent<IEffectable>();
                IBurnable burnableScript = collider.gameObject.GetComponent<IBurnable>();

                if (effectableScript != null)
                {
                    effectableScript.AddVelocity(this.transform.position, _range, _force);
                }
                if (burnableScript != null && this != burnableScript)
                {
                    burnableScript.Burning();
                }

            }
            
        Instantiate(_fireWorkParticlePrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
        }

    }

}
