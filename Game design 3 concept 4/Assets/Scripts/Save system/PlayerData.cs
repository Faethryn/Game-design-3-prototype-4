using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] position;
    public int HP;

    public PlayerData (Player player)
    {
        HP = player.HP;

        position = new float[3];
        position[0] = player.StoredTransform.position.x;
        position[1] = player.StoredTransform.position.y;
        position[2] = player.StoredTransform.position.z;
    }
}
