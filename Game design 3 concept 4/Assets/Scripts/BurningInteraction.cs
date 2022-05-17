using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningInteraction : MonoBehaviour, IBurnable, IEffectable
{
    private bool _isBurning;

    [SerializeField]
    private GameObject _burnSensor;

    [SerializeField]
    private GameObject _particleSystem;

    [SerializeField]
    private float _lifetime;

    private float _lifeTimer;

    

   

    public void Burning()
    {
        _isBurning = true;
        _particleSystem.SetActive(true);
        _burnSensor.SetActive(true);
    }

    [SerializeField]
    private MeshRenderer _meshRenderer = null;
    [SerializeField]
    [Range(-1, 2)]
    private float _dissolve = 0;

    private MaterialPropertyBlock _matPropBlock;
    private void OnValidate()
    {
        if (_meshRenderer == null) _meshRenderer = this.GetComponent<MeshRenderer>() as MeshRenderer;
        if (_matPropBlock == null) _matPropBlock = new MaterialPropertyBlock();

        _matPropBlock.SetFloat("Disolve", _dissolve);
        _meshRenderer.SetPropertyBlock(_matPropBlock);

    }

    private void Awake()
    {
        if (_meshRenderer == null) _meshRenderer = this.GetComponent<MeshRenderer>() as MeshRenderer;
        if (_matPropBlock == null) _matPropBlock = new MaterialPropertyBlock();

        _matPropBlock.SetFloat("Disolve", _dissolve);
        _meshRenderer.SetPropertyBlock(_matPropBlock);
    }

    private void Update()
    {
        if(_isBurning)
        {
           float lifeRatio = _lifeTimer / _lifetime;
            float disolveValue =  (lifeRatio * 1.5f) -0.5f ;
            _matPropBlock.SetFloat("Disolve", disolveValue);
            _meshRenderer.SetPropertyBlock(_matPropBlock);
            _lifeTimer += Time.deltaTime;
            

        }
        if (_lifeTimer >= _lifetime)
        {
            Destroy(this.gameObject);
        }

    }

    public void AddVelocity(Vector3 position, float range, float maxForce)
    {

        Vector3 ownPosition = this.transform.position;

        Vector3 positionDifference = ownPosition - position;

        float distance = Vector3.Distance(position, ownPosition);

        float forceMultiplier = (distance / range) * maxForce;

        Vector3 addedForce = Vector3.Normalize(positionDifference);

        this.GetComponent<Rigidbody>().AddForce(addedForce * forceMultiplier);
    }
}
