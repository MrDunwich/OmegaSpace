using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public GameObject prefab;

    private Queue<GameObject> objectPool = new Queue<GameObject>();

    public static ProjectilePool Instance { get; private set; }
    void Awake()
    {
        Instance = this;
        GrowPool();
    }

    // Update is called once per frame
    public GameObject GetFromPool()
    {
        if (objectPool.Count == 0) GrowPool();

        var instance = objectPool.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    private void GrowPool()
    {
        for(int i = 0; i < 30; i++)
        {
            var addInstance = Instantiate(prefab);
            addInstance.transform.SetParent(transform);
            AddToPool(addInstance);
        }

    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        objectPool.Enqueue(instance);
    }
}
