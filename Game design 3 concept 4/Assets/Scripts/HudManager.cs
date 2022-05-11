using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    [SerializeField]
    private Text _hudMatches;
    [SerializeField]
    private Text _hudFireworks;
    [SerializeField]
    private Text _hudFuel;

    public Equipment _equipment;

   public void GameLoopAwake(Equipment equipment)
    {
        _equipment = equipment;
        _hudMatches.text = "Matches: " + _equipment.Match.ToString();
        _hudFuel.text = "Fuel: " + _equipment.Fuel.ToString();
        _hudFireworks.text = "Fireworks: " + _equipment.Firework.ToString();
        _equipment.PropertyChanged += (s, e) => InventoryPropertyChanged(s, e);
    }
    protected void InventoryPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals(nameof(_equipment.Match)))
        {
            _hudMatches.text = "Matches: " + _equipment.Match.ToString() ;
        }
        if (e.PropertyName.Equals(nameof(_equipment.Fuel)))
        {
            _hudFuel.text = "Fuel: " + _equipment.Fuel.ToString();
        }
        if (e.PropertyName.Equals(nameof(_equipment.Firework)))
        {
            _hudFireworks.text = "Fireworks: " + _equipment.Firework.ToString();
        }

    }

}
