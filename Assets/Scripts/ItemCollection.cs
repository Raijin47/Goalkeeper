using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    public Image imageSkin;
    public Image imageLock;

    public void SetEnabled(bool active)
    {
        imageSkin.gameObject.SetActive(active);
        imageLock.gameObject.SetActive(!active);
    }

    public void SetSprite(Sprite sprite)
    {
        imageSkin.sprite = sprite;
    }

    public void OnClick()
    {
        Collection.Instance.SetItem(this);
    }
}