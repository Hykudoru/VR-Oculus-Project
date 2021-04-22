using UnityEngine;
using System;

//namespace Events
//{
    public class PlayerEventManager : MonoBehaviour
    {
        public delegate void GeneralEventHandler();
        public static event GeneralEventHandler InventoryUpdated;
        public static event GeneralEventHandler HandsEmpty;
        public static event GeneralEventHandler ZeroHealth;

        public delegate void InventoryEventHandler(Transform go);
        public static event InventoryEventHandler AddInventoryItem;
        public static event InventoryEventHandler RemoveInventoryItem;

        public delegate void HealthEventHandler(float amount);
        public static event HealthEventHandler HealthIncreased;
        public static event HealthEventHandler HealthDecreased;

        public delegate void PointsEventHandler(float amount);
        public static event PointsEventHandler PointsIncreased;
        public static event PointsEventHandler PointsDecreased;

        public static void OnInventoryUpdated()
        {
            if (InventoryUpdated != null)
            {
                InventoryUpdated();
            }
        }

        public static void OnHandsEmpty()
        {
            if (InventoryUpdated != null)
            {
                InventoryUpdated();
            }
        }

    public static void OnAddInventoryItem(Transform item)
        {
            if (AddInventoryItem != null)
            {
                AddInventoryItem(item);
                OnInventoryUpdated();
                Debug.Log("Stored " + item.gameObject.name + " in inventory.");
            }
        }

        public static void OnRemoveInventoryItem(Transform item)
        {
            if (RemoveInventoryItem != null)
            {
                RemoveInventoryItem(item);
                OnInventoryUpdated();
                Debug.Log("Removed " + item.gameObject.name + " from inventory.");
            }
        }

        public static void OnHealthIncreased(float amount)
        {
            if (HealthIncreased != null)
            {
                HealthIncreased(amount);
            }
        }

        public static void OnHealthDecreased(float amount)
        {
            if (HealthDecreased != null)
            {
                HealthDecreased(amount);
            }
        }

        public static void OnPointsIncreased(float amount)
        {
            if (PointsIncreased != null)
            {
                PointsIncreased(amount);
            }
        }

        public static void OnPointsDecreased(float amount)
        {
            if (PointsDecreased != null)
            {
                PointsDecreased(amount);
            }
        }

    }
//}

