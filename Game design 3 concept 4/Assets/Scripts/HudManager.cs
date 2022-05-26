using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HudManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _hudMatches;
    [SerializeField]
    private TMP_Text _hudFireworks;
    [SerializeField]
    private TMP_Text _hudFuel;

    [SerializeField]
    private TMP_Text _hudCompletion;

    [SerializeField]
    private GameObject _winCondition;

    public Equipment _equipment;

    public LevelProgression LevelProgression;

    public void GameLoopAwake(Equipment equipment, LevelProgression levelProgression)
    {
        _equipment = equipment;
        _hudMatches.text = "Matches: " + _equipment.Match.ToString();
        _hudFuel.text = "Fuel: " + _equipment.Fuel.ToString();
        _hudFireworks.text = "Fireworks: " + _equipment.Firework.ToString();
        _equipment.PropertyChanged += (s, e) => InventoryPropertyChanged(s, e);

        LevelProgression = levelProgression;
        _hudCompletion.text = "Level Completion " + LevelProgression.CurrentLevelPercentage.ToString() + "%";

        LevelProgression.PropertyChanged += (s, e) => LevelCompletionChanged(s, e);


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

    protected void LevelCompletionChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals(nameof(LevelProgression.CurrentLevelPercentage)))
        {
            _hudCompletion.text = "Level Completion: " + LevelProgression.CurrentLevelPercentage.ToString() + "%";


        }
        if (e.PropertyName.Equals(nameof(LevelProgression.WinConditionMet)))
        {
            if (LevelProgression.WinConditionMet == true)
            {
                _winCondition.SetActive(true);
            }


        }



    }


}
