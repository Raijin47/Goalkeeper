using UnityEngine;
using UnityEngine.UI;

public class AvatarButton : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private ButtonBase _button;
    [SerializeField] private Image _image;

    public Sprite Sprite => _image.sprite;
    public int ID { get => _id; set => _id = value; }

    private Material _material;
    private const string Name = "_InnerOutlineFade";

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.material = Instantiate(_image.material);
        _material = _image.materialForRendering;
        _button.OnClick.AddListener(SetAvatar);

        if (Game.Data.Saves.AvatarID == _id) IsActive = true;
    }

    public bool IsActive
    {
        set
        {
            if (_material != null)
                _material.SetFloat(Name, value ? 1 : 0);
        }
    }

    private void SetAvatar() => Game.Locator.Character.CurrentAvatar = _id;

    private void OnValidate()
    {
        _button ??= GetComponent<ButtonBase>();
        _image ??= GetComponent<Image>();
    }
}