using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{

    [SerializeField]
    private string _nextLevelName;

    public LevelProgression LevelProgression;

    //public LevelSaveSystem LevelSaveSystem;

    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = FindObjectOfType<GameLoop>().PlayerInput;
        
        _playerInput.Player.NextLevel.performed += Action;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_nextLevelName);
        _playerInput.Disable();

    }

    

    //private void SaveScore()
    //{

    //    LevelSaveSystem.SaveCompletion(LevelProgression.CurrentLevelPercentage, SceneManager.GetActiveScene().name);
    //}

    private void Action(InputAction.CallbackContext context)
    {
        if (this.gameObject.activeInHierarchy)
        {
            //SaveScore();
            LoadNextLevel();

        }
        
        
    }

    private void OnDestroy()
    {
        _playerInput.Player.NextLevel.performed -= Action;

        this.gameObject.SetActive(false);
    }
}
