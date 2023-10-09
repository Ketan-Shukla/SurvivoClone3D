using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;

public abstract class BaseObjectPool<T> : MonoBehaviour where T : UnityEngine.Component
{
    public static BaseObjectPool<T> Instance { get; private set; }

    [SerializeField]
    private T prefab;

    private readonly Queue<T> objectPool = new Queue<T>();


    private void Awake()
    {
        Instance = this;
    }

    public T GetObject()
    {
        if (objectPool.Count == 0)
        {
            AddObject();
        }

        return objectPool.Dequeue();
    }

    private void AddObject()
    {
        var newObject = Instantiate(prefab);
        newObject.gameObject.SetActive(false);
        objectPool.Enqueue(newObject);
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objectPool.Enqueue(objectToReturn);
    }


}
