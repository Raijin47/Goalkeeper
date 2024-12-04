using System;
using System.Linq;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public static Collection Instance;
    public ItemCollection[] items;
    public Sprite[] skins;
    public bool[] skinsEnabled;
    public SpriteRenderer srPlayer;

    public int SkinId 
    {
        get => PlayerPrefs.GetInt(nameof(SkinId), 0);
        set => PlayerPrefs.SetInt(nameof(SkinId), value);
    }
    private void Awake() 
    {
        Instance = this;

        PlayerPrefs.SetInt($"skin_{0}", 1);

        skinsEnabled = new bool[skins.Length];

        SetSkin(SkinId);

        gameObject.SetActive(false);
    }

    private void OnEnable() 
    {
        Visual();
    }

    private void Visual()
    {
        for (int i = 0; i < skins.Length; i++)
        {
            skinsEnabled[i] = PlayerPrefs.GetInt($"skin_{i}", 0) == 1;
            items[i].SetSprite(skins[i]);
            items[i].SetEnabled(skinsEnabled[i]);
        }
    }

    public Sprite GetPrize()
    {
        var uniqSkins = skins.Where(x => !skinsEnabled[Array.IndexOf(skins, x)]).ToArray();

        if (uniqSkins.Length == 0) return null;

        int prizeId = Array.IndexOf(skins, uniqSkins.First());

        SaveSkin(prizeId);

        return skins[prizeId];
    }

    private void SaveSkin(int id)
    {
        skinsEnabled[id] = true;
        PlayerPrefs.SetInt($"skin_{id}", 1);
    }

    internal void SetItem(ItemCollection itemCollection)
    {
        int getId = Array.IndexOf(items, itemCollection);
        
        if(skinsEnabled[getId])
        {
            SetSkin(getId);
        }
    }

    private void SetSkin(int getId)
    {
        srPlayer.sprite = skins[getId];
        SkinId = getId;
    }
}
