using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling :Singleton<ObjectPooling>
{
    public Dictionary<string,Queue<GameObject>> _poolDict;
    public List<Pool> pools;
    private void Start() {
        _poolDict = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i=0;i<=pool.size;i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            _poolDict.Add(pool.name,objectPool);
        }

    }
    public GameObject ObjectToBeSpawnned(string name,Vector3 position,Quaternion rotation)
    {
        if(!_poolDict.ContainsKey(name))
        {      
            Debug.Log("Object is not available!");
            return null;
        }
        GameObject objToBeSpawnned = _poolDict[name].Dequeue();
        objToBeSpawnned.transform.position = position;
        objToBeSpawnned.transform.rotation = rotation;
        objToBeSpawnned.SetActive(true);
        _poolDict[name].Enqueue(objToBeSpawnned);
        return objToBeSpawnned;
    }
}
[System.Serializable]
public class Pool
{
    public string name;
    public GameObject prefab;
    public int size;
}
