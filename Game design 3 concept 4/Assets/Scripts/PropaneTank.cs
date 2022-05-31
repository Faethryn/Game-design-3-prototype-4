using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private List<Collider> _alreadyExplodedColliders = new List<Collider>();

    public bool IsBurned { get; set; } = false;

    public void Burning(Collider Sender)
    {
        _alreadyExplodedColliders.Add(Sender);
        if (_burning == false)
        {


           
            
           FindObjectOfType<GameLoop>().coroutineQueue.Enqueue(BurnOthers(this.transform.position, _range, _interactibleLayers, this.GetComponent<MeshCollider>()));
            _burning = true;
            IsBurned = true;
        }
        Instantiate(_explosionPrefab, this.transform.position, this.transform.rotation);
        Instantiate(_explosionParticlePrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    IEnumerator BurnOthers(Vector3 position, float range, LayerMask interactibleLayers, Collider thisCollider)
    {
        Collider[] collidersInRange = Physics.OverlapSphere(position, range, interactibleLayers);
        


        

        foreach (Collider collider in collidersInRange)
        {
            //IEffectable effectableScript = collider.gameObject.GetComponent<IEffectable>();
            IBurnable burnableScript = collider.gameObject.GetComponent<IBurnable>();

            //if (effectableScript != null)
            //{
            //    effectableScript.AddVelocity(this.transform.position, _range, _force);
            //}
            if (burnableScript != null && this != burnableScript && burnableScript.IsBurned != true && collider.gameObject != null)
            {
                burnableScript.Burning(thisCollider);
            }

        }
        yield return new WaitForSeconds(0.2f);
    }
}
