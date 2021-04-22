using UnityEngine;
using System.Collections;

public class ItemEventMangaer : MonoBehaviour {

    public delegate void ItemGrabbedEventHandler(Transform item);
    public static event ItemGrabbedEventHandler ItemGrabbed;

    public delegate void ItemChangedEventHandler(Transform item);
    public static event ItemChangedEventHandler ItemChanged;

    public static void OnItemGrabbed(Transform item)
    {
        if (ItemGrabbed != null)
        {
            ItemGrabbed(item);
        }

        //PlayerEventManager.OnAddInventoryItem(item);
    }

    public static void OnItemChanged(Transform item)
    {
        if (ItemChanged != null)
        {
            ItemChanged(item);
        }
    }
}
