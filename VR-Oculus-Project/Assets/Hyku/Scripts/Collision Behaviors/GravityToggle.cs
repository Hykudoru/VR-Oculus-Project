using UnityEngine;
using System.Collections;

public class GravityToggle : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		Toggle(collision.rigidbody);
	}

    private void OnTriggerEnter(Collider other)
    {
        Toggle(other.GetComponent<Rigidbody>());
    }

    public static void Toggle(Rigidbody rigidbody)
    {
        if (rigidbody != null)
        {
            rigidbody.useGravity = !rigidbody.useGravity;
        }
    }
}