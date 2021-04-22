using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SetColor : Command
{
    [SerializeField] Color color = Color.white;

    public override void Execute(GameObject gameObject)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}
