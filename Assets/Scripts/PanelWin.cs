using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelWin : MonoBehaviour
{
    public Image ico;
    public TMP_Text textScore;
    public TMP_Text textName;

    void OnEnable()
    {
        var data = Game.Locator.Character;
        int score = Game.Data.Saves.Score;

        textName.text = Game.Data.Saves.Name;
        ico.sprite = data.Avatars[data.CurrentAvatar].Sprite;
        textScore.text = Game.Locator.Score.Score.ToString();
    }
}
