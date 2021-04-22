using UnityEngine;
using System.Collections;

//Performs linear transformations on Transform objects by multiplying 
//each component by the same scale factor in all directions.
public class UniformScalar : MonoBehaviour
{
	public float scalar = 0f;

	void OnCollisionEnter(Collision collision)
	{
		Multiply(collision.transform, scalar);
	}

	public static void Multiply(Transform t, float scalarQuant)
	{
		t.localScale *= scalarQuant;
	}

	public static void TwiceSize(Transform t)
	{
		Multiply(t, 2.0f);
	}

	public static void HalfSize(Transform t)
	{
		Multiply(t, 0.50f);
	}

	public static void QuarterSize(Transform t)
	{
		Multiply(t, 0.25f);
	}

}