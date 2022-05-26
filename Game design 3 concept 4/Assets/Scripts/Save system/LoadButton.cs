using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadButton : MonoBehaviour
{

    public TMP_Text text;
    public void Load()
    {
        PlayerData LoadedPlayer;
        LoadedPlayer = SaveSystem.LoadPlayer();

        text.text = "pos x: " + LoadedPlayer.position[0] + " pos y: " + LoadedPlayer.position[1] + " pos z: " + LoadedPlayer.position[2] + System.Environment.NewLine + "Player HP : " + LoadedPlayer.HP;
    }



}
    





