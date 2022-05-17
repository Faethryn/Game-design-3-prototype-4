using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffectable 
{
    public void AddVelocity(Vector3 position, float range, float maxForce);
}
