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
    private int _startingMatches;
    [SerializeField]
    private int _startingFuel;
    [SerializeField]
    private int _startingFireworks;
  
    void Start()
    {
        _equipment.Match = _startingMatches;
        _equipment.Fuel = _startingFuel;
        _equipment.Firework = _startingFireworks;
        _invFirework.Equipment = _equipment;
        _invJerrycan.Equipment = _equipment;
        _invMatch.Equipment = _equipment;
        _hudManager.GameLoopAwake(_equipment);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
