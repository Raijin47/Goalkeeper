using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetup : MonoBehaviour
{
    [SerializeField] private Image _avatarImage;
    [SerializeField] private TextMeshProUGUI _textName;
    [SerializeField] private AvatarButton[] _avatars;
    [SerializeField] private TextMeshProUGUI _textRound;

    private int _round;
    public int Round 
    {
        get => _round;
        set
        {
            _round = value;
            _textRound.text = $"Round {value}";
        }
    }

    public int CurrentAvatar
    {
        get => Game.Data.Saves.AvatarID;
        set
        {
            _avatars[CurrentAvatar].IsActive = false;
            _avatars[value].IsActive = true;
            Game.Data.Saves.AvatarID = value;
            _avatarImage.sprite = _avatars[value].Sprite;
        }
    }

    public AvatarButton[] Avatars => _avatars;

    public string SetName
    {
        set
        {
            if (value == "") return;
            Game.Data.Saves.Name = value;
            _textName.text = value;
        }
    }

    public void Init()
    {
        _textName.text = Game.Data.Saves.Name;
        CurrentAvatar = Game.Data.Saves.AvatarID;
    }

    public void ResetRound() => Round = 1;
    public void NextRound() => Round++;

    private void OnValidate()
    {
        for(int i = 0; i < _avatars.Length; i++)        
            _avatars[i].ID = i;       
    }
}