using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private float _limitX;
    [SerializeField] private float _limitY;

    private Vector2 _target;
    public bool CanMove { get; private set; }

    public Vector2 Target 
    { 
        get => _target;
        private set
        {
            _target = new Vector2(Mathf.Clamp(value.x, -_limitX, _limitX), Mathf.Clamp(value.y, 0, _limitY));
        }
    }
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        Game.Action.OnStart.AddListener(StartGame);
        Game.Action.OnLose.AddListener(() => CanMove = false);
        Game.Action.OnWin.AddListener(() => CanMove = false);
    }

    private void StartGame()
    {
        Target = Vector2.zero;
        CanMove = true;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && CanMove)
        {
            Target = _camera.ScreenToWorldPoint(Input.mousePosition);
        }  
    }
}