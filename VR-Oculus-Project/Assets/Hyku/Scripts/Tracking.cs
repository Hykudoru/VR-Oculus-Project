using UnityEngine;
using System.Collections;

public class Tracking : MonoBehaviour
{
    public float speed;
    public float closestDistance;
    private Vector3 target;
    public Vector3 Target
    {
        get { return this.target; }
        set
        {
            this.target = value;
            StopCoroutine("MoveToTarget");
            StartCoroutine("MoveToTarget", this.target);
        }
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > closestDistance)
        {
            transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);

            yield return null;
        }
    }
}