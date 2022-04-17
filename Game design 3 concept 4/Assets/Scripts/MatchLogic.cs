using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchLogic : MonoBehaviour
{


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IBurnable>().Burning();
    }
}
