using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData 
{
    public int CompletionPercentage;

    public LevelData(int inputPercentage)
    {
        CompletionPercentage = inputPercentage;
    }
}
