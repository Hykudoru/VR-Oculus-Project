using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShrinkRay : MonoBehaviour
{
    [SerializeField] LineRenderer laser;
    [SerializeField] float laserRange = 1000f;
    [SerializeField] [Range(-10f, 10)] int scaleVector = 1;
    [SerializeField] LayerMask layers;
    IEnumerator laserCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        laser.enabled = false;
    }

    public void OnTriggerLaser(InputAction.CallbackContext ctx)
    {
        if (laserCoroutine != null)
        {
            StopCoroutine(laserCoroutine);
        }
        laserCoroutine = EmitLaser(ctx);
        StartCoroutine(laserCoroutine);
    }

    IEnumerator EmitLaser(InputAction.CallbackContext ctx)
    {
        laser.enabled = true;
        while (!ctx.canceled)
        {
            Vector3 laserStartPoint = laser.transform.position;
            Vector3 defaultLaserEndPoint = laserStartPoint + transform.forward * laserRange;
            laser.SetPosition(0, laserStartPoint);
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, laserRange, layers))
            {
                laser.SetPosition(1, hitInfo.point);//.transform.position);
                OnLaserHit(hitInfo.collider);
            }
            else
            {
                laser.SetPosition(1, defaultLaserEndPoint);
            }

            yield return null;
        }
        laser.enabled = false;
        yield return null;
    }

    void OnLaserHit(Collider collider)
    {
        collider.transform.localScale += Vector3.one * scaleVector * Time.deltaTime;
    }
}
