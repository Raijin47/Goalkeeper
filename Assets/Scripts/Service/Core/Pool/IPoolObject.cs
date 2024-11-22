using UnityEngine;

public interface IPoolObject<T> where T : Object
{
    void Release();
}