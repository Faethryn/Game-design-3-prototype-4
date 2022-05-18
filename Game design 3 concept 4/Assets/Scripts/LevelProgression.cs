using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelProgression", order = 1)]
public class LevelProgression : ScriptableObject
{
    public int _currentLevelPercentage;

    public void SaveLevelScore(int CurrentLevel)
    {

    }
}
