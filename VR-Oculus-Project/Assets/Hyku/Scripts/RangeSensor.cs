using UnityEngine;
using System.Collections;

public class RangeSensor : MonoBehaviour
{
    [Tooltip("The waiting period (in seconds) between each new detection refresh. Set to 0.1 or above for better performance.")]
    public float waitTime = 0.1f;
    public float radius = 0f;
    public LayerMask layersDetectable;
    protected Collider[] collidersDetected;

    void Update()
    {
        StartCoroutine(Detect());
    }

    protected IEnumerator Detect()
    {
        collidersDetected = Physics.OverlapSphere(transform.position, radius, layersDetectable);
        yield return new WaitForSeconds(waitTime);
    }
}