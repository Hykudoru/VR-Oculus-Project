using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Debugging : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    private void Update()
    {
        OVRInput.Update();
        if (Input.GetKeyDown(KeyCode.Mouse0)
            || OVRInput.Get(OVRInput.Button.One)
            || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)
            || OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) > 0f)
        {
            obj.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
        }
        
    }
}
