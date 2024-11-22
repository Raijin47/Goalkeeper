using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    private readonly float RequiredTime = 60f;
    private readonly WaitForSeconds Dalay = new(0.2f);

    private float _currentTime;
    private float CurrentTime
    {
        get => _currentTime;
        set
        {
            _currentTime = value;
            _timerText.text = TextUtility.FormatMinute(CurrentTime);
        }
    }

    private Coroutine _coroutine;


    private void Start()
    {
        Game.Action.OnStart.AddListener(StartTimer);
        Game.Action.OnLose.AddListener(Release);
    }

    private void StartTimer()
    {
        Release();
        _coroutine = StartCoroutine(TimerProcess());
    }

    private IEnumerator TimerProcess()
    {
        CurrentTime = RequiredTime;
        yield return Dalay;

        while (CurrentTime >= 0)
        {
            CurrentTime -= Time.deltaTime;
            yield return null;
        }

        CurrentTime = 0;
        Game.Action.SendWin();
    }

    private void Release()
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
}