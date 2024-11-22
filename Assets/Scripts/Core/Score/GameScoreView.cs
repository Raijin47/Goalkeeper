using System.Collections;
using TMPro;
using UnityEngine;

public class GameScoreView : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private float _current;

    private readonly float Speed = 5;
    private Coroutine _changeProcess;

    private int _previewScore;

    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    private void OnEnable()
    {
        Game.Locator.Score.OnChangeScore += Change;
        _previewScore = Game.Locator.Score.Score;
        Set(Game.Locator.Score.Score);
    }

    private void OnDisable()
    {
        Game.Locator.Score.OnChangeScore -= Change;
        Game.Data.Saves.IsScoreChanged = Game.Locator.Score.Score != _previewScore;
        Release();
    }

    private void Set(float value)
    {
        _current = value;
        _text.text = $"{Mathf.RoundToInt(_current)}";
    }

    private void Change()
    {
        if (!gameObject.activeInHierarchy) return;
        Release();
        _changeProcess = StartCoroutine(ChangeScoreProcess());
    }

    private IEnumerator ChangeScoreProcess()
    {
        while (Mathf.Abs(_current - Game.Locator.Score.Score) > 1)
        {
            Set(Mathf.Lerp(_current, Game.Locator.Score.Score, Time.deltaTime * Speed));
            yield return null;
        }
        Set(Game.Locator.Score.Score);
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