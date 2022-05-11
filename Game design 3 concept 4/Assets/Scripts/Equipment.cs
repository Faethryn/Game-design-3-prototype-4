using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Equipment : MonoBehaviour, INotifyPropertyChanged
{
    private int _fuel;

    public int Fuel { get { return _fuel; } set { if (_fuel == value) return; _fuel = value; OnPropertyChanged(); } }

    private int _match;

    public int Match { get { return _match; } set { if (_match == value) return; _match = value; OnPropertyChanged(); } }

    private int _firework;

    public int Firework { get { return _firework; } set { if (_firework == value) return; _firework = value; OnPropertyChanged(); } }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged([CallerMemberName] string PropertyName = "")
    {
        var handler = PropertyChanged;
        handler?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }

    public Equipment(int matches, int fuel, int fireworks)
    {
        _fuel = fuel;
        _match = matches;
        _firework = fireworks;
    }

}
