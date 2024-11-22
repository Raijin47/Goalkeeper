using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private LeaderboardElement[] _elements;
    private readonly string[] _names = 
    {
        "Scarlett", "Mason", "Luna", "Hudson", "Isla", "Beshot", "Fox",
        "Grayson", "Nova", "Asher", "Skye", "Elijah", "Bloodshaper", "Arisa",
        "Willow", "Jasper", "Savannah", "Ryder", "Freya", "Finn", "Shadow",
        "Elara", "Aria", "Phoenix", "Lincoln", "Harper", "Kai", "Jerry",
        "Piper", "Roman", "Aurora", "Atlas", "Sienna", "Beckham", "Jack",
        "Delilah", "Lila", "Jonah", "Rowan", "Ember", "Jaxon", "Quinn", "Zara",
        "Micah", "Everly", "Declan", "Marlowe", "Beckett", "Seraphina", "Kieran",
        "Giselle","Wilder","Evangeline","Nico","Juniper","Colton","Ophelia"
    };

    private int _rank = -1;
    private float _currentTime = 0;
    private bool _canUpdate = true;

    private void OnEnable()
    {
        if (_canUpdate) UpdateUI();
        else if(Mathf.Abs(_currentTime - Time.time) > 360f) UpdateUI();
    }

    private void UpdateUI()
    {
        _currentTime = Time.time;
        Debug.Log(_elements.Length);
        var data = Game.Locator.Character;
        int score = Game.Data.Saves.Score;
        _rank = _rank == -1 ? Random.Range(200, 999) : _rank + Random.Range(-10, 10);

        var player = _elements[^1];
        player.Avatar = data.Avatars[data.CurrentAvatar].Sprite;
        player.Rank = _rank;
        player.Name = Game.Data.Saves.Name;
        player.Score = score;

        for (int i = _elements.Length - 2; i >= 0; i--)
        {
            score += Random.Range(50, 500);

            _elements[i].Avatar = data.Avatars[Random.Range(0, data.Avatars.Length)].Sprite;
            _elements[i].Rank = _rank - _elements.Length + i + 1;
            _elements[i].Name = _names[Random.Range(0, _names.Length)];
            _elements[i].Score = score;
        }

        _canUpdate = false;
    }
}