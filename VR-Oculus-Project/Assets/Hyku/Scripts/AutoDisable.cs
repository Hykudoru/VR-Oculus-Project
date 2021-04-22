using UnityEngine;
using System.Collections;

public class AutoDisable : MonoBehaviour
{
    public float lifeTime = 0f;
    public bool disableOnCollision = false;
    
    void OnEnable()
    {
        Invoke("disable", lifeTime);
    }

    void OnDisable()
    {
        CancelInvoke("disable");
    }

    void OnCollisionEnter()
    {
        if (disableOnCollision)
        {
            disable();
        }
    }

    void disable()
    {
        gameObject.SetActive(false);
    }
}