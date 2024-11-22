using System;
using UnityEngine;

public abstract class PoolMember : MonoBehaviour
{
    public event Action<PoolMember> Die;

    public abstract void Init();
    public abstract void ResetData();
    public abstract void Release();
    public void ReturnToPool() => Die?.Invoke(this);
}