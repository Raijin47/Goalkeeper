using UnityEngine;

public class LeagueView : MonoBehaviour
{
    [SerializeField] private GameObject[] _leagues;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        Game.Locator.Score.OnChangeLeague += ChangeLeague;
        if (_animator != null) _animator.Play("Play");
        Changed();
    }

    private void OnDisable()
    {
        Game.Locator.Score.OnChangeLeague -= ChangeLeague;
    }

    private void ChangeLeague()
    {
        if (_animator != null) _animator.Play("Change");
    }

    public void Changed()
    {
        for (int i = 0; i < _leagues.Length; i++)
            _leagues[i].SetActive(i == Game.Data.Saves.League);
    }
}