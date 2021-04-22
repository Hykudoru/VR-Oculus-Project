using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[RequireComponent(typeof (Rigidbody))]
public class Launcher : MonoBehaviour 
{
    private float timer = 0f;
    private short currentSlot = 0;
    private List<Transform> slots;
    private PlayerInventory playerInventory;
    public bool unlimited = false;
    
    public GameObject[] objectsAllowed;
    public Transform pointOfEmission;
    [Range(1f, 100f)] public byte rate = 1;
	[Range(0f, 100f)] public float power = 0f;
	[Tooltip("Causes item to rotate about its L-R horizontal axis upon discharge.")]
	[Range(-1, 1)] public short torqueX = 0;
	[Tooltip("Causes item to rotate about its vertical axis upon discharge.")]
	[Range(-1, 1)] public short torqueY = 0;
	[Tooltip("Causes item to rotate about its B-F horizontal axis upon discharge.")]
	[Range(-1, 1)] public short torqueZ = 0;

	void FixedUpdate() 
	{
		timer += Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (unlimited)
            {
                InstantiateAndLaunch();
            }
            else {
                SpawnAndLaunch();
            }
		}

        /*
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentSlot < (inventory.Count-1))
            {
                currentSlot++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentSlot > 0)
            {
                currentSlot--;
            }
        } */
    }

    private void SpawnAndLaunch()
    {
        if (slots.Count > 0 && pointOfEmission && timer >= (1.0f / rate))
        {
            timer = 0f;
            Transform item = slots[currentSlot];
            item.transform.SetParent(null);
            item.transform.localScale = new Vector3(1, 1, 1);
            item.transform.position = pointOfEmission.position;
            item.transform.rotation = pointOfEmission.rotation;
            Launch(item.GetComponent<Rigidbody>());
            PlayerEventManager.OnRemoveInventoryItem(item);
        }
    }

    private void InstantiateAndLaunch()
	{
        if (objectsAllowed.Length > 0 && pointOfEmission && timer >= (1.0f / rate))
        {
            timer = 0f;
            GameObject clone = (GameObject) Instantiate(objectsAllowed[currentSlot], pointOfEmission.position, pointOfEmission.rotation);
            Launch(clone.GetComponent<Rigidbody>());
		}
	}

	private void Launch(Rigidbody rb)
	{
		rb.AddForce(transform.forward * power, ForceMode.VelocityChange);
		rb.AddTorque(transform.right * torqueX, ForceMode.VelocityChange);
		rb.AddTorque(transform.up * torqueY, ForceMode.VelocityChange);
		rb.AddTorque(transform.forward * torqueZ, ForceMode.VelocityChange);
		rb.useGravity = true;
		rb.detectCollisions = true;
	}
}