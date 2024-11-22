using System;
using UnityEngine;

[Serializable]
public class Locator
{
    [SerializeField] private CharacterSetup _character;
    [SerializeField] private PlayerBase _player;
    [SerializeField] private LeagueData _data;
    [SerializeField] private TotalScore _score;
    [SerializeField] private Bootstrap _bootstrap;

    public CharacterSetup Character => _character;
    public PlayerBase Player => _player;
    public LeagueData Data => _data;
    public TotalScore Score => _score;
    public Bootstrap Bootstrap => _bootstrap;
}