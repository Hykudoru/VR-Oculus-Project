using UnityEngine;
using System.Collections;

public class Paint : MonoBehaviour
{
    private Color color;
    public Color Color;
    public bool randomColor = false;

    void Start()
    {
        if (randomColor) {
            color = CoverSurface(GetComponent<MeshRenderer>());
        } else {
            color = Color;
            CoverSurface(GetComponent<MeshRenderer>(), color);
        }
    }

	void OnCollisionEnter(Collision collision)
	{
        CoverSurface(collision.collider, color);
	}

	public static Color CoverSurface(MeshRenderer meshren)
	{
		Color ranColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0f, 1f);
        meshren.material.color = ranColor;

        return ranColor;
    }

	public static void CoverSurface(MeshRenderer meshren, Color color)
	{
        meshren.material.color = color;
	}

	public static Color CoverSurface(Collider collider)
	{
        Color ranColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0f, 1f);
        collider.GetComponent<MeshRenderer>().material.color = ranColor;

        return ranColor;
	}

	public static void CoverSurface(Collider collider, Color color)
	{
		collider.GetComponent<MeshRenderer>().material.color = color;
	}

}