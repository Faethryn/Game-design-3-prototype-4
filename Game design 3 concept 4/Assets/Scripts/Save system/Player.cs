using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP = 40;
    public Transform StoredTransform;

    private void Start()
    {
        StoredTransform = this.transform;
    }

    public void UpdateTransform()
    {
        StoredTransform = this.transform;
    }

}
