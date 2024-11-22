using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private Collider2D _collider;
    private float Force { get; set; }
    private int Score { get; set; }

    private InputHandler _input;
    private bool CanMove { get => _collider.enabled; set => _collider.enabled = value; }
    private float _speed;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _speed = Game.Locator.Data.PlayerSpeed;
        CanMove = false;
        _input = GetComponent<InputHandler>();
        Game.Action.OnStart.AddListener(StartGame);
        Game.Action.OnLose.AddListener(() => CanMove = false);
        Game.Action.OnWin.AddListener(() => CanMove = false);
    }

    private void StartGame()
    {
        transform.localPosition = Vector2.zero;
        Force = Game.Locator.Data.Force * 0.5f;
        Score = Mathf.RoundToInt(Mathf.Pow(Game.Locator.Data.DegreeScore, Game.Locator.Character.Round) * Game.Locator.Data.BaseScore);
        CanMove = true;
    }

    private void Update()
    {
        if (!CanMove) return;

        transform.localPosition = Vector2.MoveTowards(transform.localPosition, _input.Target, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ball ball))
        {
            Vector2 dir = Vector2.Reflect(ball.Rigidbody.velocity, Vector2.up);
            ball.Rigidbody.velocity = Vector2.zero;
            ball.Rigidbody.AddForce(dir.normalized * Force, ForceMode2D.Impulse);
            ball.Collider.enabled = false;
            ball.Dispose();

            Game.Audio.PlayClip(0);
            Game.Locator.Score.Score += Score;
        }

        if (collision.TryGetComponent(out Garbage _))
        {
            Game.Locator.Score.Score -= 500;
            Game.Action.SendGameOver();
        }

   
    }
}