using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public Image boxImage;
    public Sprite[] boxSprites;

    public Image bar;
    public TMP_Text textProgress;

    public Image rectItem;
    public Image itemSkin;

    public int addProgress = 100;
    public int maxProgress = 300;

    public int progress
    {
        get => PlayerPrefs.GetInt(nameof(progress), 0);
        set => PlayerPrefs.SetInt(nameof(progress), value);
    }

    private void OnEnable()
    {
        bool getPrize = CheckProgress();
        rectItem.transform.localScale = Vector3.zero;

        if (getPrize)
        {
            Sprite sprite = Collection.Instance.GetPrize();
            itemSkin.sprite = sprite;
            rectItem.transform.DOScale(1,  2);
        }

        Visual(getPrize);
    }

    private bool CheckProgress()
    {
        progress += addProgress;

        if (progress > maxProgress)
        {
            progress = addProgress;
        }

        return progress >= maxProgress;
    }

    private void Visual(bool openBox)
    {
        bar.fillAmount = (float)progress / maxProgress;

        boxImage.sprite = boxSprites[openBox ? 1 : 0];
        boxImage.SetNativeSize();

        textProgress.text = $"{progress}/{maxProgress}";
    }
}
