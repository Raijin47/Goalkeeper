using System.Collections;
using TMPro;
using UnityEngine;

public class MenuScoreView : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private float _current;
    private readonly float Speed = 5;
    private Coroutine _changeProcess;

    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    private void OnEnable()
    {
        Release();
        if (Game.Data.Saves.IsScoreChanged) _changeProcess = StartCoroutine(ChangeRecordProcess());
        else Set(Game.Locator.Score.Score);
    }

    private void OnDisable() => Release();

    private void Set(float value)
    {
        _current = value;
        _text.text = $"{Mathf.RoundToInt(_current)}";
    }

    private IEnumerator ChangeRecordProcess()
    {
        while (Mathf.Abs(_current - Game.Locator.Score.Score) > 1)
        {
            Set(Mathf.Lerp(_current, Game.Locator.Score.Score, Time.deltaTime * Speed));
            yield return null;
        }
        Set(Game.Locator.Score.Score);
        Game.Data.Saves.IsScoreChanged = false;
        Game.Locator.Score.CheckLeague();
    }

    private void Release()
    {
        if (_changeProcess != null)
        {
            StopCoroutine(_changeProcess);
            _changeProcess = null;
        }
    }
}