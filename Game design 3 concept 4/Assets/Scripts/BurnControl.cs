using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnControl : MonoBehaviour
{
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
}
