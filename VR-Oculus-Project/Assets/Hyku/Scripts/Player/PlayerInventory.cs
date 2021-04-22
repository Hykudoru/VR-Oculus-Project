using UnityEngine;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour
{
    private List<Transform> objectInventory;

    void Start()
    {
       objectInventory = new List<Transform>();
    }

    void OnEnable()
    {
        PlayerEventManager.AddInventoryItem += Store;
        PlayerEventManager.RemoveInventoryItem += Remove;
    }

    void OnDisable()
    {
        PlayerEventManager.AddInventoryItem -= Store;
        PlayerEventManager.RemoveInventoryItem -= Remove;
    }

    private void Store(Transform item)
    {
        if (objectInventory.Count <= 3)
        {
            item.gameObject.SetActive(false);
            item.SetParent(transform);
            if (!item.CompareTag("InventoryItem"))
            {
                item.tag = "InventoryItem";
                objectInventory.Add(item);
            }
        }
    }

    private void Remove(Transform item)
    {
        if (objectInventory.Contains(item))
        {
            item.gameObject.tag = "Item"; 
            item.gameObject.SetActive(true);
            item.SetParent(null);
            objectInventory.Remove(item);
        }
    }

}