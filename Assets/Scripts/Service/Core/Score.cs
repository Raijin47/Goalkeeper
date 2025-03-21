using System;
using UnityEngine;

[Serializable]
public class Score : Component
{
    public event Action OnAddScore;
    public event Action OnResetScore;


    private int _record;
    private int _score;

    private readonly string SaveName = "Record";

    public int Record => _record;
    public int Current => _score;

    public override void Init()
    {
        _record = PlayerPrefs.GetInt(SaveName, 0);
        Game.Action.OnStart.AddListener(StartGame);
    }

    private void StartGame() 
    {
        _score = _record;
        OnResetScore?.Invoke();
    } 

    public void Add(int value)
    {
        _score += value;
        OnAddScore?.Invoke();
    }

    public bool GetRecord()
    {
        if (_score > _record)
        {
            _record = _score;
            Save();
            return true;
        }
        else return false;
    }

    public void Decrease(int value)
    {
        _record -= value;
        Save();
    }

    private void Save() => PlayerPrefs.SetInt(SaveName, _record);
}