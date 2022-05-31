using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBurnable 
{
    public bool IsBurned { get; set; }
    public void Burning(Collider Sender);
}
