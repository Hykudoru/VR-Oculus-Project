using UnityEngine;
using System.Collections;

public class RaycastSensor : MonoBehaviour 
{
	[Range(1f, 1000000f)]
    public float maxDistance;
	public LayerMask layersDetectable;
	protected RaycastHit hitInfo;

	protected bool DetectColliders()
	{
		return Physics.Raycast(transform.position + transform.forward, transform.forward, out hitInfo, maxDistance, layersDetectable);
	}
}