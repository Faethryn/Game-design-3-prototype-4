using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{

    [SerializeField]
    private string _nextLevelName;

    public LevelProgression LevelProgression;

    public LevelSaveSystem LevelSaveSystem;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_nextLevelName);

    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SaveScore();
            LoadNextLevel();
        }
    }

    private void SaveScore()
    {

        LevelSaveSystem.SaveCompletion(LevelProgression.CurrentLevelPercentage, SceneManager.GetActiveScene().name);
    }


}
