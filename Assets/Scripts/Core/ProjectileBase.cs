using System.Collections;
using UnityEngine;

public abstract class ProjectileBase : PoolMember
{
    [SerializeField] private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    //private MaterialPropertyBlock _materialPropertyBlock;
    private Material _material;
    private Coroutine _coroutine;

    private float _fadeValue;

    private readonly int FadePropertyID = Shader.PropertyToID("_FullDistortionFade");

    public Rigidbody2D Rigidbody => _rigidbody;
    protected float FadeValue
    {
        get => _fadeValue;
        set
        {
            _fadeValue = value;
            _material.SetFloat(FadePropertyID, _fadeValue);
            //_materialPropertyBlock.SetFloat(FadePropertyID, _fadeValue);
            //_spriteRenderer.SetPropertyBlock(_materialPropertyBlock);
        }
    }

    public override void Init()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_materialPropertyBlock = new MaterialPropertyBlock();
        _material = _spriteRenderer.material;
        Game.Action.OnStart.AddListener(ReturnToPool);
    }

    public void Dispose()
    {
        Release();
        _coroutine = StartCoroutine(FadingProcess());
    }

    public override void Release()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator FadingProcess()
    {
        FadeValue = 1;

        while (FadeValue > 0)
        {
            FadeValue -= Time.deltaTime;

            if (FadeValue <= 0)
            {
                FadeValue = 1;
                ReturnToPool();
                yield break;
            }
            yield return null;
        }
    }
}