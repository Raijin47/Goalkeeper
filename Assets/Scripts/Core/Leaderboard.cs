using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private LeaderboardElement[] _elements;
    // private readonly string[] _names = 
    // {
    //     "Scarlett", "Mason", "Luna", "Hudson", "Isla", "Beshot", "Fox",
    //     "Grayson", "Nova", "Asher", "Skye", "Elijah", "Bloodshaper", "Arisa",
    //     "Willow", "Jasper", "Savannah", "Ryder", "Freya", "Finn", "Shadow",
    //     "Elara", "Aria", "Phoenix", "Lincoln", "Harper", "Kai", "Jerry",
    //     "Piper", "Roman", "Aurora", "Atlas", "Sienna", "Beckham", "Jack",
    //     "Delilah", "Lila", "Jonah", "Rowan", "Ember", "Jaxon", "Quinn", "Zara",
    //     "Micah", "Everly", "Declan", "Marlowe", "Beckett", "Seraphina", "Kieran",
    //     "Giselle","Wilder","Evangeline","Nico","Juniper","Colton","Ophelia"
    // };

    private Dictionary<string, int> _names;

    private int _rank = -1;
    private float _currentTime = 0;
    private bool _canUpdate = true;

    private void OnEnable()
    {
        //if (_canUpdate) 
        UpdateUI();
        //else if(Mathf.Abs(_currentTime - Time.time) > 360f) UpdateUI();
    }

    private void UpdateUI()
    {
        _currentTime = Time.time;
        Debug.Log(_elements.Length);
        var data = Game.Locator.Character;
        int score = Game.Data.Saves.Score;
        //_rank = _rank == -1 ? Random.Range(200, 999) : _rank + Random.Range(-10, 10);

        var player = _elements[^1];
        player.Avatar = data.Avatars[data.CurrentAvatar].Sprite;
        player.Rank = _rank;
        player.Name = Game.Data.Saves.Name;
        player.Score = score;

        _names = Nicknames.GetNicknames();
        _names.Add(Game.Data.Saves.Name, score);
        var sortedNames = _names.OrderByDescending(x => x.Value).ToList();

        // Находим индекс текущего игрока в отсортированном списке
        int playerRank = sortedNames.FindIndex(x => x.Key == Game.Data.Saves.Name);

        // Обновляем данные игрока
        player.Rank = playerRank;

        // Выводим отсортированный список имен и счетов
        print(sortedNames);

        // Обновляем данные для остальных элементов
        for (int i = _elements.Length - 2; i >= 0; i--)
        {
    int rank = playerRank - (_elements.Length - 1 - i);
            if (rank < 0) return;

            _elements[i].Avatar = data.Avatars[UnityEngine.Random.Range(0, data.Avatars.Length)].Sprite;
            _elements[i].Rank = rank;
            _elements[i].Name = sortedNames[rank].Key;
            _elements[i].Score = sortedNames[rank].Value;
        }
    }


}