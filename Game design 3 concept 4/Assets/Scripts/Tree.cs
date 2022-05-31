using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IBurnable
{
    private bool _isBurning;
    [SerializeField]
    private GameObject _particleSystem;

    [SerializeField]
    private float _lifetime;

    private float _lifeTimer;

    private bool _spawnedSound = false;

    [SerializeField]
    private GameObject _soundPrefab;
   
    [SerializeField]
    private GameObject _FireCollider;

    public LevelProgression _levelProgression;


    public void Burning(Collider Sender)
    {
        _isBurning = true;
        _particleSystem.SetActive(true);
        Instantiate(_FireCollider, this.transform);

    }

    [SerializeField]
    private MeshRenderer _meshRenderer = null;
    [SerializeField]
    [Range(-1, 2)]
    private float _dissolve = 0;

    private MaterialPropertyBlock _matPropBlock;

    public bool IsBurned { get; set; }

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
        if (_isBurning)
        {
            float lifeRatio = _lifeTimer / _lifetime;
            float disolveValue = (lifeRatio * 1.5f) - 0.5f;
            _matPropBlock.SetFloat("Disolve", disolveValue);
            _meshRenderer.SetPropertyBlock(_matPropBlock);
            _lifeTimer += Time.deltaTime;
            if (!_spawnedSound)
            {
              GameObject spawnedSoundObject =  Instantiate(_soundPrefab, this.transform);
                _spawnedSound = true;
                spawnedSoundObject.GetComponent<AudioSource>().Play();
            }

        }
        if (_lifeTimer >= _lifetime)
        {
            _levelProgression.RemoveTree(this);
            Destroy(this.gameObject);
        }

    }
}
