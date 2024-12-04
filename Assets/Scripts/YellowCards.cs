using UnityEngine;
using UnityEngine.UI;

public class YellowCards : MonoBehaviour
{
    public Image[] yellowCards;
    public Sprite[] sprites;

    void Update()
    {
        for (int i = 0; i < yellowCards.Length; i++)
        {
            yellowCards[i].sprite = sprites[Game.Locator.yellowCard <= i ? 1 : 0];
        }
    }
}
