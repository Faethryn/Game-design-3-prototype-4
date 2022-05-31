using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private Equipment _equipment;
    [SerializeField]
    private InventoryFireWork _invFirework;
    [SerializeField]
    private InventoryJerrycan _invJerrycan;
    [SerializeField]
    private InventoryMatch _invMatch;
    [SerializeField]
    private HudManager _hudManager;

    [SerializeField]
    private LevelProgression _levelProgression;

    [SerializeField]
    private ToNextScene _nextSceneLoader;


    //[SerializeField]
    //private LevelSaveSystem _levelSaveSystem;

    [SerializeField]
    private int _startingMatches;
    [SerializeField]
    private int _startingFuel;
    [SerializeField]
    private int _startingFireworks;

    public PlayerInput PlayerInput ;


    [SerializeField]
    private GameObject _pauseScreen;

    [SerializeField]
    private string _menuSceneName;

    public Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator>();

  

    IEnumerator CoroutineCoordinator()
    {
        while (true)
        {
            while (coroutineQueue.Count > 0)
                yield return StartCoroutine(coroutineQueue.Dequeue());
            yield return null;
        }
    }


    private void Awake()
    {
        PlayerInput = new PlayerInput();
        PlayerInput.Player.Enable();
    }



    void Start()
    {
        StartCoroutine(CoroutineCoordinator());

        _levelProgression._gameLoop = this;
        House[] tempHouses = GameObject.FindObjectsOfType<House>();
        _levelProgression.AddHouses(tempHouses);

        Tree[] tempTrees = GameObject.FindObjectsOfType<Tree>();
        _levelProgression.AddTrees(tempTrees);

        _levelProgression.SetStartingScore();



        _equipment.Match = _startingMatches;
        _equipment.Fuel = _startingFuel;
        _equipment.Firework = _startingFireworks;
        _invFirework.Equipment = _equipment;
        _invJerrycan.Equipment = _equipment;
        _invMatch.Equipment = _equipment;
        _hudManager.GameLoopAwake(_equipment, _levelProgression);


        _levelProgression.PropertyChanged += (s, e) => LevelCompletionChanged(s, e);

        _nextSceneLoader.LevelProgression = _levelProgression;

        PlayerInput.Player.PauseButton.performed += Pause;
        PlayerInput.Player.RestartLevel.performed += Restart;
        PlayerInput.Player.BackToMenu.performed += BackToMenu;
        //_nextSceneLoader.LevelSaveSystem = _levelSaveSystem;


    }

    protected void LevelCompletionChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals(nameof(LevelProgression.WinConditionMet)))
        {
            
            if (_levelProgression.WinConditionMet == true)
            {
                Debug.Log("You may continue");

                _nextSceneLoader.gameObject.SetActive(true);


            }

        }

    }

    private void Pause(InputAction.CallbackContext context)
    {

        if (_pauseScreen.activeInHierarchy == false)
        {
            _pauseScreen.SetActive(true);
            Time.timeScale = 0;

            

        }
     else   if (_pauseScreen.activeInHierarchy == true)
        {
            _pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }


      



    }

    private void BackToMenu(InputAction.CallbackContext context)
    {
        if (_pauseScreen.activeInHierarchy == true)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(_menuSceneName);
        }
    }

    private void Restart(InputAction.CallbackContext context)
    {
        if (_pauseScreen.activeInHierarchy == true)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnDestroy()
    {
        PlayerInput.Player.PauseButton.performed -= Pause;
        PlayerInput.Player.RestartLevel.performed -= Restart;
        PlayerInput.Player.BackToMenu.performed -= BackToMenu;
    }



}
