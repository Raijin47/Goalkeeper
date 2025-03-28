using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    [SerializeField] private GameAudio _audio;
    [SerializeField] private GameAction _action;
    [SerializeField] private Locator _locator;
    [SerializeField] private SaveService _data;

    [Space(10)]
    [SerializeReference, SubclassSelector] private Wallet _walletType;
    [SerializeReference, SubclassSelector] private AudioSettings _audioType;

    [Space(10)]
    [SerializeReference, SubclassSelector] private List<Component> _components;

    public static GameAudio Audio;
    public static Wallet Wallet;
    public static GameAction Action;
    public static Locator Locator;
    public static SaveService Data;

    public AudioSettings AudioSettings => _audioType;

    private void Awake()
    {
        Instance = this;
        Audio = _audio;
        Wallet = _walletType;
        Action = _action;
        Locator = _locator;
        Data = _data;

        Application.targetFrameRate = 60;

        foreach (Component component in _components)
            component.Init();
    }

    private void Start()
    {
        _walletType.Init();
        _audioType.Init();
        _audio.Init();
        _data.LoadingData();
    }

    public T Get<T>() where T : Component
    {
        return (T)_components.FirstOrDefault(component => component is T);
    }

    public void SetCountYellowCard(int count)
    {
        Locator.yellowCard = count;
    }

    public void StartGame() => Action.SendStartGame();
    public void GameOver() => Action.SendGameOver();
    public void Restart() => Action.SendRestart();
    public void AddMoney(int value) => Wallet.Add(value);
    public void SaveProgress() => _data.SaveProgress();
}