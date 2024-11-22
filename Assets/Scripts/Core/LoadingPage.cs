using UnityEngine;

public class LoadingPage : MonoBehaviour
{
    [SerializeField] private GameObject _loadingPage;
    public void Initialized()
    {
        Game.Locator.Bootstrap.Init();
        Destroy(_loadingPage);
    }
}