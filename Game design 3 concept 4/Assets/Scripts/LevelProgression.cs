using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;



public class LevelProgression : MonoBehaviour, INotifyPropertyChanged
{
   

    private int _currentLevelPercentage;

    public int CurrentLevelPercentage { get { return _currentLevelPercentage; } set { if (_currentLevelPercentage == value) return; _currentLevelPercentage = value; OnPropertyChanged(); } }

    public List<House> Houses = new List<House>();

    private float _initialHouseCount;

    public List<Tree> Trees = new List<Tree>();

    private float _initialTreeCount;

    private float _startingValue;

    public GameLoop _gameLoop;

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string PropertyName = "")
    {
        var handler = PropertyChanged;
        handler?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }

    public void SaveLevelScore(int CurrentLevel)
    {

    }

    private void RecalculateScore()
    {
        float currentHouseAmount = Houses.Count;
        float currentTreeAmount = Trees.Count;

        float currentValue = currentHouseAmount + (currentTreeAmount /2);

        CurrentLevelPercentage = (int)(100 - ((currentValue / _startingValue) * 100));

    }

    public void SetStartingScore()
    {
        _startingValue = _initialHouseCount + (_initialTreeCount / 2);
    }

    public void RemoveTree(Tree removedTree)
    {
        Trees.Remove(removedTree);

        RecalculateScore();




    }

    public void RemoveHouse(House removedHouse)
    {
        Houses.Remove(removedHouse);
        RecalculateScore();
    }

    public void AddHouses(House[] houseObjects)
    {
        foreach (House house in houseObjects)
        {
            Houses.Add(house);
            house._levelProgression = this;
        }
        _initialHouseCount = Houses.Count;

        
    }

    public void AddTrees(Tree[] treeObjects)
    {
        foreach (Tree tree in treeObjects)
        {
            Trees.Add(tree);
            tree._levelProgression = this;
        }
        _initialTreeCount = Trees.Count;

       
    }

    
}
