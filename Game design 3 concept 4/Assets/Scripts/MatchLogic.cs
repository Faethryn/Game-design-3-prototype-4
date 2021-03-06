using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchLogic : MonoBehaviour
{


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        //other.GetComponent<IBurnable>().Burning();
       StartCoroutine(Burning(other.GetComponent<IBurnable>(), this.GetComponent<SphereCollider>(), other.gameObject));
    }

    IEnumerator Burning(IBurnable burnObject, Collider thisCollider, GameObject otherObject)
    {
      if (otherObject != null)
        {

        burnObject.Burning(thisCollider);
        }

        

        yield return new WaitForSeconds(0.2f);
    }
}
