using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private bool IsActive { get; set; }

    private void Start()
    {
        Game.Action.OnLose.AddListener(() => IsActive = false);
        Game.Action.OnWin.AddListener(() => IsActive = false);
        Game.Action.OnStart.AddListener(() => IsActive = true);     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsActive) return;

        Game.Locator.AddYellowCard(1);
        //Game.Locator.Score.Score -= Game.Locator.Data.DecreaseScore;
    }
}