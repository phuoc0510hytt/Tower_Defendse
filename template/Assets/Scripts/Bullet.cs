using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;
	public float speed = 70f;
	public GameObject impactEffect;

	public void seek(Transform _target)
	{
		target = _target;
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			Destroy(gameObject);
			return;
		}
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		if (dir.magnitude <= distanceThisFrame) {
			HitTarget();
			return;
		}
		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
	}
	void HitTarget()
	{
		GameObject Effect = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (Effect, 2f);
		Destroy (target.gameObject);
		Destroy (gameObject);
	}
}
