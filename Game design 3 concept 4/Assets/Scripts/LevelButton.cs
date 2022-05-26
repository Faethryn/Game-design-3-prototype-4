using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField]
    private string _levelName;

    [SerializeField]
    private TMP_Text _completionText;

    [SerializeField]
    private LevelSaveSystem _levelSaveSystem;


    private void Awake()
    {
        LevelData tempData = _levelSaveSystem.LoadCompletion(_levelName);

        _completionText.text = "Completion: " + tempData.CompletionPercentage + " %";
    }


    public void LoadLevel()
    {
        SceneManager.LoadScene(_levelName);
    }

}
