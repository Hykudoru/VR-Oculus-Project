using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Explode : Command
{
    [SerializeField] float magnitude = 1f;
    [SerializeField] float radius = 1f;

    public override void Execute(GameObject gameObject)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>() as Rigidbody;
        if (rb)
        {
            rb.AddExplosionForce(magnitude, rb.position, radius, 1f, ForceMode.Impulse);
        }
    }
}