using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Scriptable Data", order = 51)]
public class LeagueData : ScriptableObject
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _baseScore;
    [SerializeField] private float _degreeScore;
    [SerializeField] private int _decreaseScore;

    [Space(10)]
    [SerializeField] private LeagueComplexity[] _complexity;

    public int DecreaseScore => _decreaseScore;
    public float BaseScore => _baseScore;
    public float DegreeScore => _degreeScore;

    public float PlayerSpeed => _playerSpeed;
    public float Force => _complexity[Game.Data.Saves.League].Force;
    public float IntervalSpawn => _complexity[Game.Data.Saves.League].IntervalSpawn;
    public float ChanceGarbage => _complexity[Game.Data.Saves.League].ChanceGarbage;
    public float TimeGame => _complexity[Game.Data.Saves.League].TimeGame;
}

[Serializable]
public class LeagueComplexity
{
    [SerializeField] private float _force;
    [SerializeField] private float _intervalSpawn;
    [SerializeField][Range(0,1)] private float _chanceGarbage;
    [Range(1,120)]
    [SerializeField] private float _timeGame;

    public float Force => _force;
    public float IntervalSpawn => _intervalSpawn;
    public float ChanceGarbage => _chanceGarbage;
    public float TimeGame => _timeGame;
}