using UnityEngine;
using System.Collections.Generic;

public class Storage : MonoBehaviour
{
    private List<GameObject> storedObjects;

    void Start()
    {
        storedObjects = new List<GameObject>();
    }

    public void Insert(GameObject obj)
    {
        obj.SetActive(false);
        storedObjects.Add(obj);
    }

    public GameObject Remove(GameObject obj)
    {
        if (storedObjects.Remove(obj))
        {
            return obj;
        }

        return null;
    }
}
