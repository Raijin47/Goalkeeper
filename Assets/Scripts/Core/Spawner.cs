using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Ball _ball;
    [SerializeField] private Garbage _garbage;
    [SerializeField] private Transform _content;
    [SerializeField] private Transform _target;

    private float Force { get; set; }
    private float TimeToSpawn { get; set; }
    private float Chance { get; set; }

    private float _currentTime;

    private Coroutine _coroutine;

    private Pool _poolBall;
    private Pool _poolGarbage;

    private void Start()
    {
        _poolBall = new(_ball, _content);
        _poolGarbage = new(_garbage, _content);

        _camera = Camera.main;
        Game.Action.OnStart.AddListener(StartGame);
        Game.Action.OnLose.AddListener(Release);
        Game.Action.OnWin.AddListener(Release);
    }

    private void StartGame()
    {
        Debug.Log(Game.Locator.Character.Round);
        float round = Game.Locator.Character.Round;
        TimeToSpawn = Mathf.Pow(0.9f, round) * Game.Locator.Data.IntervalSpawn; 
        Force = Mathf.Pow(1.05f, round) * Game.Locator.Data.Force;
        Chance = Mathf.Pow(1.05f, round) * Game.Locator.Data.ChanceGarbage;

        Release();
        _coroutine = StartCoroutine(SpawnProcess());
    }

    private IEnumerator SpawnProcess()
    {
        while(true)
        {
            if(_currentTime >= TimeToSpawn)
            {
                _currentTime = 0;
                Spawn();
            }

            _currentTime += Time.deltaTime;
            yield return null;
        }
    }

    private void Spawn()
    {
        ProjectileBase newObject = (ProjectileBase)(Random.value > Chance ?
            _poolBall.Spawn(GetPosition()) :
            _poolGarbage.Spawn(GetPosition()));

        newObject.Rigidbody.AddForce(GetDirection(newObject.transform.localPosition) * Force, ForceMode2D.Impulse);
        newObject.Rigidbody.AddTorque(Random.value * 10);
    }

    private void Release()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private Vector2 GetPosition()
    {
        Vector2 screenPoint = Vector2.up * 1.2f;
        screenPoint.x = Random.Range(-0.5f, 1.5f);

        return _camera.ViewportToWorldPoint(screenPoint);
    }

    private Vector2 GetDirection(Vector2 pos)
    {
        Vector2 randomTarget = new (Random.Range(-2, 2), _target.localPosition.y);
        return (randomTarget - pos).normalized;
    }
}