using System;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public event Action OnChangeScore;
    public event Action OnChangeLeague;

    public int Score
    {
        get => Game.Data.Saves.Score;
        set
        {
            Game.Data.Saves.Score = Mathf.Clamp(value, 0, int.MaxValue);
            Game.Data.SaveProgress();
            OnChangeScore?.Invoke();
        }
    }

    public void CheckLeague()
    {
        if (Game.Data.Saves.League == GetLeague()) return;

        Game.Data.Saves.League = GetLeague();
        Game.Data.SaveProgress();
        OnChangeLeague?.Invoke();
    }

    private int GetLeague()
    {
        return Score switch
        {
            < 1000 => 0,
            < 2000 => 1,
            < 5000 => 2,
            < 9000 => 3,
            < 15000 => 4,
            _ => 5
        };
    }
}