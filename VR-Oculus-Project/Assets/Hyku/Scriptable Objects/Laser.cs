using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Laser : ScriptableObject
{
    [SerializeField] Color color = Color.red;

    public void Init(BeamEmitter mbLaser, LineRenderer line)
    {
        line.startColor = color;
        line.endColor = color;
        line.material.color = color;
    }
}
