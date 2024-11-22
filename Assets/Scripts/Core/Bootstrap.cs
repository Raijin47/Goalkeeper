using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _panelEdit;
    [SerializeField] private GameObject _panelMain;
    
    public void Init()
    {
        if (Game.Data.IsReady) GetData();
        else Game.Data.OnSavesLoaded += GetData;
    }

    private void GetData()
    {
        Game.Locator.Character.Init();
        _panelEdit.SetActive(Game.Data.Saves.IsFirstSession);
        _panelMain.SetActive(!Game.Data.Saves.IsFirstSession);
    }

    public void Apply()
    {
        _panelEdit.SetActive(false);
        _panelMain.SetActive(true);

        Game.Data.Saves.IsFirstSession = false;
        Game.Data.SaveProgress();
    }
}