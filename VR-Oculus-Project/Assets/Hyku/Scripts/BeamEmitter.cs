using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeamEmitter : RaycastSensor
{
	private LineRenderer lineRenderer;
	private ParticleSystem energyParticleSystem;
	[SerializeField] Laser laser;
	[SerializeField] List<Command> Button1Commands = new List<Command>();
	[SerializeField] List<Command> Button2Commands = new List<Command>();
	public event Action<GameObject> OnRayHit = delegate { };
	public void SetColor(Color c) { lineRenderer.material.color = c; } 
	void Awake()
	{
		lineRenderer = GameObject.Find("PointOfEmission").GetComponent<LineRenderer>();
		energyParticleSystem = GameObject.Find("PointOfEmission").GetComponent<ParticleSystem>();

		AssignCommands(Button1Commands);
    }

	void AssignCommands(List<Command> commands)
    {
		if (commands != null && commands.Count > 0)
		{
			OnRayHit = delegate { };
			foreach (var command in commands)
			{
				OnRayHit += command.Execute;
			}
		}
	}

	void Start()
	{
		lineRenderer.enabled = false;
		if (energyParticleSystem.isPlaying)
		{
			energyParticleSystem.Stop();
		}
		laser.Init(this, lineRenderer);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StopCoroutine("ActivateBeam");
			AssignCommands(Button1Commands);
			key = KeyCode.Mouse0;
			StartCoroutine("ActivateBeam");
		}
		else if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			StopCoroutine("ActivateBeam");
			AssignCommands(Button2Commands);
			key = KeyCode.Mouse1;
			StartCoroutine("ActivateBeam");
		}
	}

	KeyCode key;
	IEnumerator ActivateBeam()
	{
		energyParticleSystem.Play();
		lineRenderer.enabled = true;

		while (Input.GetKey(key))
        {
            Vector3 startPoint = transform.position + transform.forward;
            Vector3 endPoint = transform.forward * base.maxDistance;
            
            lineRenderer.SetPosition(0, startPoint);
			if (base.DetectColliders())
            {
				lineRenderer.SetPosition(1, base.hitInfo.point);
				Invoke("RayHit", 0.1f);
			}
            else
            {
				lineRenderer.SetPosition(1, endPoint);
			}

			yield return null;
		}

        lineRenderer.enabled = false;
        energyParticleSystem.Stop();
	}
		
	protected virtual void RayHit()
	{
		Transform t = hitInfo.transform as Transform;
		if (t)
		{
			ITriggerable trigger = t.GetComponent<PlayerTrigger>() as ITriggerable;
			if (trigger != null)
			{
				trigger.Trigger();
			}
			else
			{
				OnRayHit?.Invoke(t.gameObject);
			}
		}
		
		//laser?.Execute();
		//Gravity.ToggleGravity(hitInfo.rigidbody);
		//Explosion.OriginExplosion(hitInfo.rigidbody, 25f);
		//UniformScalar.Multiply(hitInfo.transform, 1.05f);
		//UniformScalar.Multiply(hitInfo.transform, 0.95f);
		//if (hitInfo.rigidbody != null) {
		//hitInfo.rigidbody.AddForceAtPosition(transform.forward*50f, hitInfo.point, ForceMode.Impulse);
		//}
	}

}