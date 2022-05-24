using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int _startingMatches;
    [SerializeField]
    private int _startingFuel;
    [SerializeField]
    private int _startingFireworks;
  
    void Start()
    {
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


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
