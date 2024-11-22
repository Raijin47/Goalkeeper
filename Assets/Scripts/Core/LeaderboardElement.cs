using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textRank;
    [SerializeField] private TextMeshProUGUI _textName;
    [SerializeField] private TextMeshProUGUI _textTotalScore;
    [SerializeField] private Image _avatar;

    public Sprite Avatar
    {
        set => _avatar.sprite = value;
    }

    public int Rank
    {
        set => _textRank.text = $"#\n{value}";
    }

    public string Name
    {
        set => _textName.text = value;
    }

    public int Score
    {
        set => _textTotalScore.text = value.ToString();
    }
}