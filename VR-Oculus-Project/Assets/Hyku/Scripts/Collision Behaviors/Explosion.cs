using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
	[Range(0f, 300f)] public float blastForce = 0f;
	[Range(0f, 300f)] public float blastRadius = 0f;
	public LayerMask layersDetect;

	void OnCollisionEnter(Collision collision)
	{
		if (blastRadius == 0f) {
			OriginExplosion(collision.rigidbody, blastForce);
		} else {
			Collider[] detected = Physics.OverlapSphere(transform.position, blastRadius, layersDetect);
			PointRadiusExplosion(detected, transform.position, blastForce, blastRadius);
		}
	}

    //All methods/overloaded methods verify rigidbodies are present before applying physics.

    public static void OriginExplosion(Rigidbody rb, float blastForce)
	{
		if (rb != null) {
			rb.AddExplosionForce(blastForce, rb.position, 0, 1, ForceMode.Impulse);
		}
	}

	public static void OriginExplosion(Rigidbody[] rbs, float force)
	{
		foreach (Rigidbody rb in rbs) {
			if (rb != null) {
				rb.AddExplosionForce(force, rb.position, 0, 1, ForceMode.Impulse);
			}
		}
	}

	public static void OriginExplosion(Collider collider, float force)
	{
		if (collider.attachedRigidbody != null) {
			collider.attachedRigidbody.AddExplosionForce(force, collider.transform.position, 0, 1, ForceMode.Impulse);
		}
	}

	public static void OriginExplosion(Collider[] colliders, float force)
	{
		foreach (Collider collider in colliders) {
			if (collider.attachedRigidbody != null) {
				collider.attachedRigidbody.AddExplosionForce(force, collider.transform.position, 1, 1, ForceMode.Impulse);
			}
		}
	}

	//All methods/overloaded methods verify rigidbodies are present before applying physics.

	public static void PointRadiusExplosion(Rigidbody rb, Vector3 explosionPosition, float force, float radius)
	{
		if (rb != null) {
			rb.AddExplosionForce(force, explosionPosition, radius, 1, ForceMode.Impulse);
		}
	}

	public static void PointRadiusExplosion(Collider collider, Vector3 explosionPosition, float force, float radius)
	{
		if (collider.attachedRigidbody != null) {
			collider.attachedRigidbody.AddExplosionForce(force, explosionPosition, radius, 1, ForceMode.Impulse);
		}
	}

	public static void PointRadiusExplosion(Rigidbody[] rbs, Vector3 explosionPosition, float force, float radius)
	{
		foreach (Rigidbody rb in rbs) {
			if (rb != null) {
				rb.AddExplosionForce(force, explosionPosition, radius, 1, ForceMode.Impulse);
			}
		}
	}

	public static void PointRadiusExplosion(Collider[] colliders, Vector3 explosionPosition, float force, float radius)
	{
		foreach (Collider collider in colliders) {
			if (collider.attachedRigidbody != null) {
				collider.attachedRigidbody.AddExplosionForce(force, explosionPosition, radius, 1, ForceMode.Impulse);
			}
		}
	}

}