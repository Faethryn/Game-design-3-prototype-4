using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSource : MonoBehaviour
{
    [SerializeField]
    private AudioClip _thisClip;

    private float _maxTimer;

    private float _timer;

        private void Awake()
    {
        _timer = 0;
        _maxTimer = _thisClip.length;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _maxTimer)
        {
            Destroy(this.gameObject);
        }
    }
}
