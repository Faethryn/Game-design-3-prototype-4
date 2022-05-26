using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public Player player;
    public void Save()
    {
       
        SaveSystem.SavePlayer(player);
    }

}
