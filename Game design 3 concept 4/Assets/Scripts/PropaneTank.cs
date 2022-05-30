using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropaneTank : MonoBehaviour, IBurnable
{
    [SerializeField]
    private float _range;
    [SerializeField]
    private float _force;
    [SerializeField]
    private LayerMask _interactibleLayers;


    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _explosionParticlePrefab;

    private bool _burning = false;

    public void Burning()
    {
        if (_burning == false)
        {


            Collider[] collidersInRange = Physics.OverlapSphere(this.transform.position, _range, _interactibleLayers);
            foreach (Collider collider in collidersInRange)
            {
                //IEffectable effectableScript = collider.gameObject.GetComponent<IEffectable>();
                IBurnable burnableScript = collider.gameObject.GetComponent<IBurnable>();

                //if (effectableScript != null)
                //{
                //    effectableScript.AddVelocity(this.transform.position, _range, _force);
                //}
                if (burnableScript != null && this != burnableScript)
                {
                    burnableScript.Burning();
                }

            }
            _burning = true;
        }
        Instantiate(_explosionPrefab, this.transform.position, this.transform.rotation);
        Instantiate(_explosionParticlePrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
