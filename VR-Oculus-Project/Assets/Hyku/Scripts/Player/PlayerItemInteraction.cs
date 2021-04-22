using UnityEngine;
using System.Collections.Generic;

public class PlayerItemInteraction : RaycastSensor
{
    public Transform hand;
    private GameObject itemHolding;

    void Update()
    {
        //DROP|GRAB ITEMS (E)
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemHolding != null)
            {
                DropItem();
            }

            //Grab any item detected.
            if (base.DetectColliders())
            {
                GrabItem(base.hitInfo.collider.transform);
            }
        }

        //STORE ITEMS (Q)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Store current item in hand if no other colliders detected.
            if (itemHolding != null && !base.DetectColliders())
            {
                SaveItem(itemHolding.transform);
                itemHolding = null;
            }

            //Store other item detected while ignoring item in hand if exists. 
            if (base.DetectColliders())
            {
                SaveItem(base.hitInfo.collider.transform);
            }
        }
    }
   
    private void GrabItem(Transform item)
    {
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.position = hand.position + hand.forward * 0.75f;
        item.rotation = hand.rotation;
        item.SetParent(hand.transform);
        item.gameObject.SetActive(true);
        itemHolding = item.gameObject;
    }

    private void DropItem()
    {
        if (itemHolding != null)
        {
            itemHolding.transform.SetParent(null);
            itemHolding.GetComponent<Rigidbody>().isKinematic = false;
            itemHolding = null;
        }
    }

    private void SaveItem(Transform item)
    {
        PlayerEventManager.OnAddInventoryItem(item);
    }
}