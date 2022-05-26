using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    private string _levelName;
   public void LoadScene()
    {
        SceneManager.LoadScene(_levelName);
    }
}
